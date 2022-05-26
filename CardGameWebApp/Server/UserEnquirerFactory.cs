using CardGameWebApp.Server.Hubs;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.SignalR;

namespace CardGameWebApp.Server
{
    public class UserEnquirerFactory : IUserEnquirerFactory
    {
        private readonly IHubContext<GameHub> gameHub;
        private readonly InquiryResponseOperator inquiryResponse;

        public UserEnquirerFactory(IHubContext<GameHub> gameHub, InquiryResponseOperator inquiryResponse)
        {
            this.gameHub = gameHub ?? throw new System.ArgumentNullException(nameof(gameHub));
            this.inquiryResponse = inquiryResponse ?? throw new System.ArgumentNullException(nameof(inquiryResponse));
        }

        public IUserEnquirer Create(PlayerRepository playerRepository)
        {
            return new UserEnquirer(gameHub, playerRepository, inquiryResponse);
        }
    }
}
