using CardGameWebApp.Shared;
using dk.itu.game.msc.cgdl.Representation;
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
        private readonly SessionService service;

        public SessionsController(SessionService service)
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
        public ActionResult Create([FromBody] Guid sessionId)
        {
            service.Create(sessionId);
            return CreatedAtAction(nameof(GetSession), new { id = sessionId });
        }

        [HttpGet("{id:int}")]
        public ActionResult<SessionDTO> GetSession(Guid id)
        {
            var session = service.GetSession(id);
            if (session == null)
                return NotFound();

            return new SessionDTO(session.Instance);
        }
    }
}
