﻿using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CollectionBust : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public string Collection { get; }

        public CollectionBust(DateTime eventTime, Guid processId, string collection)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Collection = collection;
        }
    }
}
