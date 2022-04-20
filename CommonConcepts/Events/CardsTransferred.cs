using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardsTransferred : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Source { get; }
        public string Destination { get; }

        public CardsTransferred(DateTime eventTime, Guid processId, string source, string destination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Destination = destination;
        }
    }
}
