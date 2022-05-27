using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Representation
{
    public class SessionService
    {
        private readonly SessionRepository repository;
        private readonly SessionFactory factory;

        public SessionService(SessionRepository repository, SessionFactory factory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IEnumerable<Session> ListSessions()
        {
            return repository.ListSessions();
        }

        public void Create(Guid id, IUserEnquirerFactory userEnquirer)
        {
            var session = factory.CreateSession(id, userEnquirer);
            repository.AddSession(session);
        }

        public Session? GetSession(Guid id)
        {
            return repository.GetSession(id);
        }
    }
}
