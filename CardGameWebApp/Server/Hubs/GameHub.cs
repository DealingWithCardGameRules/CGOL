﻿using dk.itu.game.msc.cgdl.Representation;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Hubs
{
    public class GameHub : Hub
    {
        private readonly SessionService service;

        public GameHub(SessionService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task Join(Guid sessionId)
        {
            var session = service.GetSession(sessionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());
        }

        public async Task SelectPlayer(Guid sessionId, int playerIndex)
        {
            var session = service.GetSession(sessionId);
            session.PlayerRepository.AddPlayer(playerIndex, Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());
            await Clients.Group(sessionId.ToString()).SendAsync("PlayerJoined", playerIndex);
        }

        public async Task ReleasePlayer(Guid sessionId, int playerIndex)
        {
            var session = service.GetSession(sessionId);
            session.PlayerRepository.RemovePlayer(playerIndex);
            await Clients.Group(sessionId.ToString()).SendAsync("PlayerLeft", playerIndex);
        }

        public async Task Leave(Guid sessionId)
        {
            var session = service.GetSession(sessionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionId.ToString());
        }

        public async Task CardSelected(Guid sessionId)
        {
            var session = service.GetSession(sessionId);

        }
    }
}
