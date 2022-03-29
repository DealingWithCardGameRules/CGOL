﻿using CardGameWebApp.Server.Hubs;
using CardGameWebApp.Shared.Inquiries;
using dk.itu.game.msc.cgdl.Representation;
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

        public Guid? SelectCard(int playerIndex, string collection, string[] requiredTags)
        {
            var clientId = playerRepository.GetPlayer(playerIndex);
            if (clientId == null)
                return null;

            Guid? returnValue = null;
            Task.Run(() =>
            {
                Guid corId = Guid.NewGuid();
                responseOperator.Expect<Guid?>(corId, (card) => returnValue = card);
                gameHub.Clients.Client(clientId).SendAsync("SelectCard", new SelectCardInquiry(corId, collection, requiredTags));
                while (returnValue == null) ;

            }).Wait();
            return returnValue;
        }
    }
}