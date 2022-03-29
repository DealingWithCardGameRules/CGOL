using CardGameWebApp.Shared.DTOs;
using System;

namespace CardGameWebApp.Shared.Responses
{
    public class GameOverviewResponse : LinksExtension
    {
        public Guid SessionId { get; set; }
        public GameStateDTO Game { get; set; }
        public GameOverviewResponse() { } // Serialize constructor
        public GameOverviewResponse(string selfLink) : base(selfLink)
        {
        }
    }
}
