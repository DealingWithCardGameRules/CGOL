using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DiscardCard : ICommand
    {
        public Guid ProcessId => new Guid("611C60C2-6D26-4E09-9366-F8C8222C7990");
        public Guid Instance { get; }
		public int PlayerIndex { get; }

		public DiscardCard(int playerIndex)
        {
            Instance = Guid.NewGuid();
			PlayerIndex = playerIndex - 1;
		}
    }
}
