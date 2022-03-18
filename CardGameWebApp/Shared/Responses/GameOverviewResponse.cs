using CardGameWebApp.Shared.DTOs;

namespace CardGameWebApp.Shared.Responses
{
    public class GameOverviewResponse : LinksExtension
    {
        public GameStateDTO Game { get; set; }
        public GameOverviewResponse(string selfLink) : base(selfLink)
        {
        }
    }
}
