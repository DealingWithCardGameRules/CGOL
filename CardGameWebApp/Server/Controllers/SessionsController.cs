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
        private readonly SessionRepository repository;
        private readonly SessionFactory factory;

        public SessionsController(SessionRepository repository, SessionFactory factory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [HttpGet]
        public SessionList GetList()
        {
            var sessionDTOs = repository.ListSessions().Select(s => new SessionDTO(s.Instance));
            return new SessionList(sessionDTOs, Request.GetEncodedUrl());
        }

        [HttpPost]
        public ActionResult Create([FromBody] Guid sessionId)
        {
            var session = factory.Create(sessionId);
            repository.AddSession(session);
            return CreatedAtAction(nameof(GetSession), new { id = sessionId });
        }

        [HttpGet("{id:int}")]
        public ActionResult<SessionDTO> GetSession(Guid id)
        {
            var session = repository.GetSession(id);
            if (session == null)
                return NotFound();

            return new SessionDTO(session.Instance);
        }
    }
}
