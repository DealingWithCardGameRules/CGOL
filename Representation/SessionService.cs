﻿using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionService
    {
        private readonly SessionRepository repository;
        private readonly SessionFactory factory;

        public SessionService(SessionRepository repository, SessionFactory factory)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new System.ArgumentNullException(nameof(factory));
        }

        public IEnumerable<Session> ListSessions()
        {
            return repository.ListSessions();
        }

        public void Create(Guid id, IUserEnquirerFactory userEnquirer)
        {
            var session = factory.Create(id, userEnquirer);
            repository.AddSession(session);
        }

        public Session? GetSession(Guid id)
        {
            return repository.GetSession(id);
        }
    }
}
