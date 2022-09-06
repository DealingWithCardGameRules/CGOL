using CardGameWebApp.Server.Hubs;
using CardGameWebApp.Shared.Inquiries;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CardGameWebApp.Server
{
    public class UserEnquirer : IUserEnquirer
    {
        private readonly IHubContext<GameHub> gameHub;
        private readonly PlayerRepository playerRepository;
        private readonly InquiryResponseOperator responseOperator;

        public UserEnquirer(IHubContext<GameHub> gameHub, PlayerRepository playerRepository, InquiryResponseOperator responseOperator)
        {
            this.gameHub = gameHub ?? throw new ArgumentNullException(nameof(gameHub));
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.responseOperator = responseOperator ?? throw new ArgumentNullException(nameof(responseOperator));
        }

        public bool AskPlayer(int playerIndex, string message)
        {
            var clientId = playerRepository.GetPlayer(playerIndex);
            if (clientId == null)
                return false;

            bool? returnValue = null;
            Task.Run(() =>
            {
                Guid corId = Guid.NewGuid();
                responseOperator.Expect<bool>(corId, (result) => returnValue = result);
                gameHub.Clients.Client(clientId).SendAsync("AskPlayer", new AskPlayerInquiry(corId, message));
                while (returnValue == null);
            }).Wait();
            return returnValue ?? false;
        }

        public Guid? SelectCard(int playerIndex, string collection, string[] requiredTags, bool required)
        {
            throw new NotImplementedException();
        }

        //public Guid? SelectCard(int playerIndex, string collection, string[] requiredTags, bool required)
        //{
        //    var clientId = playerRepository.GetPlayer(playerIndex);
        //    if (clientId == null)
        //        return null;

        //    Guid? returnValue = null;
        //    Task.Run(() =>
        //    {
        //        Guid corId = Guid.NewGuid();
        //        responseOperator.Expect<Guid?>(corId, (card) => returnValue = card);
        //        gameHub.Clients.Client(clientId).SendAsync("SelectCard", new SelectCardInquiry(corId, collection, requiredTags, required));
        //        while (returnValue == null);
        //    }).Wait();
        //    return returnValue;
        //}

        public void SendConclusion(string message)
        {
            gameHub.Clients.Group(playerRepository.Group).SendAsync("Conclusion", message);
        }
    }
}
