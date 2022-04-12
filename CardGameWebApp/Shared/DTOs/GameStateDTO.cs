using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class GameStateDTO
    {
        public int NumberOfPlayers { get; set; } = 0;
        public IDictionary<string, string> Decks { get; set; }
        public IDictionary<string, string> Hands { get; set; }
        public IDictionary<string, string> Zones { get; set; }
    }
}
