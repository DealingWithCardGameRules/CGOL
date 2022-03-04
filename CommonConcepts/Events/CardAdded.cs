﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardAdded : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public DateTime EventTime1 { get; }
        public Guid ProcessId1 { get; }
        public ICard Card { get; }
        public string Destination { get; }

        public CardAdded(DateTime eventTime, Guid processId, ICard card, string destination)
        {
            EventTime1 = eventTime;
            ProcessId1 = processId;
            Card = card;
            Destination = destination;
        }
    }
}
