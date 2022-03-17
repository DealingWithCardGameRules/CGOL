using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PlayCard : ICommand
    {
        public Guid ProcessId => new Guid("AE58E7BB-29E7-41D6-882B-0AD6BA00F5E6");
        public string Source { get; }
        public string Destination { get; }
        [Play] public Guid? Card { get; set; }

        public PlayCard(string source, string destination, Guid? card = null)
        {
            Card = card;
            Source = source;
            Destination = destination;
        }
    }
}
