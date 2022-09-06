using CardGameWebApp.Server.Hubs;
using CardGameWebApp.Shared;
using CardGameWebApp.Shared.Responses;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly SessionServiceWrapper service;
        private readonly IHubContext<GameHub> gameHub;

        public SessionsController(SessionServiceWrapper service, IHubContext<GameHub> gameHub)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.gameHub = gameHub ?? throw new ArgumentNullException(nameof(gameHub));
        }

        [HttpGet]
        public SessionList GetList()
        {
            var sessionDTOs = service.ListSessions().Select(s => new SessionDTO(s.Instance));
            return new SessionList(sessionDTOs, Request.GetEncodedUrl());
        }

        [HttpPost]
        public ActionResult Create()
        {
            var id = Guid.NewGuid();
            service.Create(id, new WebContext { User = "anonymous" });
            return Created(Url.Action(nameof(GetSession), "sessions", new { id }, Request.Scheme), null);
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<SessionResponse> GetSession(Guid id)
        {
            var session = service.GetSession(id);
            if (session == null)
                return NotFound();

            var output = new SessionResponse(Request.GetEncodedUrl())
            {
                Session = new SessionDTO(session.Instance)
            };
            output.Links.Add("concepts", Url.Action("Index", "concepts", new { id }, Request.Scheme));
            output.Links.Add("game", Url.Action("GetGame", "game", new { id }, Request.Scheme));
            output.Links.Add("savegame", Url.Action(nameof(SaveGame), "sessions", new { id }, Request.Scheme));
            return output;
        }

        [HttpPost("{id:Guid}/savegame")]
        public async Task<ActionResult> SaveGame(Guid id)
        {
            var current = service.GetSession(id);
            current.Save();
            return Ok();
        }

        [HttpPut("{id:Guid}/savegame")]
        public async Task<ActionResult> RestoreGame(Guid id)
        {
            if (service.GetSession(id)?.Saved == null)
                return NotFound();

            var events = service.GetSession(id).Saved;
            service.Reset(id, new WebContext { User = "anonymous" });
            var session = service.GetSession(id);
            session.Service.Replay(events);
            session.Save();
            await gameHub.Clients.Group(id.ToString()).SendAsync("NewState");
            return Ok();
        }
    }
}
