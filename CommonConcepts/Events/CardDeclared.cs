using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Template { get; }
        public ICardTemplate Card { get; }
        public string Name { get; }

        public CardDeclared(DateTime eventTime, Guid processId, string template, ICardTemplate card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Template = template;
            Card = card;
        }
    }
}
