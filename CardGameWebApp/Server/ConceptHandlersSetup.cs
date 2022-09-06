using CardGameWebApp.Server.Handlers;
using CardGameWebApp.Server.Hubs;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.SignalR;

namespace CardGameWebApp.Server
{
    public class ConceptHandlersSetup : IPluginSetup
    {
        private readonly StorageService storage;
        private readonly WebContext webcontext;
        private readonly IHubContext<GameHub> gameHub;
        private readonly PlayerRepository playerRepository;
        private readonly InquiryResponseOperator responseOperator;

        public ConceptHandlersSetup(StorageService storage, WebContext webcontext, IHubContext<GameHub> gameHub, PlayerRepository playerRepository, InquiryResponseOperator responseOperator)
        {
            this.storage = storage;
            this.webcontext = webcontext;
            this.gameHub = gameHub;
            this.playerRepository = playerRepository;
            this.responseOperator = responseOperator;
        }

        public void Setup(IPluginContext context)
        {
            context.Interpreter.AddConcept(new LoadCardHandler(context.Dispatcher, storage, webcontext));
            context.Interpreter.AddConcept(new PickACardUserHandler(gameHub, playerRepository, responseOperator));
        }
    }
}
