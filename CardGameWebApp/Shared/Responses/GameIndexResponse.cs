namespace CardGameWebApp.Shared.Responses
{
    public class GameIndexResponse : LinksExtension
    {
        public CreateGameDTO Game { get; set; }

        public GameIndexResponse() { } // Serialize constructor

        public GameIndexResponse(string selfLink) : base(selfLink)
        {
        }
    }
}
