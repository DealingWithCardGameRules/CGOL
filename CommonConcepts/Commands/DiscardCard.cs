using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DiscardCard : ICommand
    {
        public Guid ProcessId => new Guid("611C60C2-6D26-4E09-9366-F8C8222C7990");
        public Guid Instance { get; }
		public int? PlayerIndex { get; }
        public string From { get; }
        public string To { get; }

        [Concept(Description = "Ask a player to discard a card from one collection into an other collection. If no player index is set, the owner of the collection will be asked.")]
		public DiscardCard(string from, string to, int playerIndex = 0)
        {
            Instance = Guid.NewGuid();
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
