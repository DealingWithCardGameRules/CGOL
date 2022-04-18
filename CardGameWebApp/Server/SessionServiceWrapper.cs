using dk.itu.game.msc.cgdl.FluxxConcepts;
using dk.itu.game.msc.cgdl.Representation;
using System;
using System.Collections.Generic;

namespace CardGameWebApp.Server
{
    public class SessionServiceWrapper
    {
        private readonly SessionService session;
        private readonly IUserEnquirerFactory userEnquirerFactory;
        private readonly StorageService storage;

        public SessionServiceWrapper(SessionService session, IUserEnquirerFactory userEnquirerFactory, StorageService storage)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            this.userEnquirerFactory = userEnquirerFactory ?? throw new ArgumentNullException(nameof(userEnquirerFactory));
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void Create(Guid id, WebContext context)
        {
            session.Create(id, userEnquirerFactory);
            var ses = session.GetSession(id);
            ses.Service.LoadConcepts(new FluxxConceptsSetup());
            ses.Interpolator.AddConcept(new LoadCardHandler(ses.Service, storage, context));
        }

        public Session GetSession(Guid id)
        {
            return session.GetSession(id);
        }

        public IEnumerable<Session> ListSessions()
        {
            return session.ListSessions();
        }
    }
}
