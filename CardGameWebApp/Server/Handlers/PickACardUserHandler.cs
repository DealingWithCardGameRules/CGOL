using CardGameWebApp.Server.Hubs;
using CardGameWebApp.Shared.DTOs;
using CardGameWebApp.Shared.Inquiries;
using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Handlers
{
    public class PickACardUserHandler : IQueryHandler<PickACard, Guid?>
    {
        private readonly IHubContext<GameHub> gameHub;
        private readonly PlayerRepository playerRepository;
        private readonly InquiryResponseOperator responseOperator;

        public PickACardUserHandler(IHubContext<GameHub> gameHub, PlayerRepository playerRepository, InquiryResponseOperator responseOperator)
        {
            this.gameHub = gameHub ?? throw new ArgumentNullException(nameof(gameHub));
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.responseOperator = responseOperator ?? throw new ArgumentNullException(nameof(responseOperator));
        }

        public async Task<Guid?> Handle(PickACard query)
        {
            var clientId = playerRepository.GetPlayer(query.Player);
            if (clientId == null)
                return null;

            Guid? returnValue = null;
            Task.Run(() =>
            {
                Guid corId = Guid.NewGuid();
                responseOperator.Expect<Guid?>(corId, (card) => returnValue = card);
                gameHub.Clients.Client(clientId).SendAsync("SelectCard", new SelectCardInquiry(corId, Convert(query.Selection), query.Required));
                while (returnValue == null) Task.Yield();
            }).Wait();
            return returnValue;
        }

        private IEnumerable<CardRefDTO> Convert(IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {

                yield return new CardRefDTO
                {
                    Instance = card.Instance,
                    Name = card.Template
                };
            }
        }
    }
}
