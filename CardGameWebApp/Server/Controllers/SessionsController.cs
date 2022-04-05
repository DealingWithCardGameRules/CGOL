using CardGameWebApp.Shared;
using CardGameWebApp.Shared.Responses;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly SessionServiceWrapper service;

        public SessionsController(SessionServiceWrapper service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
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
            return output;
        }
    }
}
