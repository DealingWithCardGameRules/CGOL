﻿using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class TurnStarted : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        [Concept(Description = "The new turn started.")]
        public TurnStarted(DateTime eventTime, Guid processId)
        {
            EventTime = eventTime;
            ProcessId = processId;
        }
    }
}
