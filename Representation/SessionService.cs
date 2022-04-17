using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionService : ISessionService
    {
        private readonly SessionRepository repository;
        private readonly SessionFactory factory;
        private readonly IPluginContext pluginContext;

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
            var session = factory.CreateSession(id, userEnquirer);
            repository.AddSession(session);
        }

        public Session? GetSession(Guid id)
        {
            return repository.GetSession(id);
        }
    }
}
