using CardGameWebApp.Server.Hubs;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace CardGameWebApp.Server
{
    public class SessionServiceWrapper
    {
        private readonly SessionService session;
        private readonly IUserEnquirerFactory userEnquirerFactory;
        private readonly StorageService storage;
        private readonly IHubContext<GameHub> gameHub;
        private readonly InquiryResponseOperator inquiryResponse;

        public SessionServiceWrapper(SessionService session, IUserEnquirerFactory userEnquirerFactory, StorageService storage, IHubContext<GameHub> gameHub, InquiryResponseOperator inquiryResponse)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            this.userEnquirerFactory = userEnquirerFactory ?? throw new ArgumentNullException(nameof(userEnquirerFactory));
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.gameHub = gameHub;
            this.inquiryResponse = inquiryResponse;
        }

        public void Create(Guid id, WebContext context)
        {
            session.Create(id, userEnquirerFactory);
            var ses = session.GetSession(id);
            ses.Service.LoadConcepts(new ConceptHandlersSetup(storage, context, gameHub, ses.PlayerRepository, inquiryResponse));
        }

        public Session GetSession(Guid id)
        {
            return session.GetSession(id);
        }

        public IEnumerable<Session> ListSessions()
        {
            return session.ListSessions();
        }

        internal void Reset(Guid id, WebContext webContext)
        {
            session.Reset(id, userEnquirerFactory);
            var ses = session.GetSession(id);
            ses.Service.LoadConcepts(new ConceptHandlersSetup(storage, webContext, gameHub, ses.PlayerRepository, inquiryResponse));
        }
    }
}
