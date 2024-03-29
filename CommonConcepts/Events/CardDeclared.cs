﻿using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Template { get; }
        public ICardTemplate Card { get; }

        [Concept(Description = "A card was declared.")]
        public CardDeclared(DateTime eventTime, Guid processId, string template, ICardTemplate card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Template = template;
            Card = card;
        }

        public override string ToString()
        {
            return $"The card \"{Template}\" was declared";
        }
    }
}
