using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class GameStateDTO
    {
        public IDictionary<string, string> Decks { get; set; }
        public IDictionary<string, string> Hands { get; set; }
        public IDictionary<string, string> Community { get; set; }

    }
}
