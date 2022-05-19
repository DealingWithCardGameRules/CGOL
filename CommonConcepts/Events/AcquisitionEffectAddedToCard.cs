﻿using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class AcquisitionEffectAddedToCard : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string UniqueCardName { get; }
        public ICommand Command { get; }

        [Concept(Description = "A when drawn effect was added to a card.")]
        public AcquisitionEffectAddedToCard(DateTime eventTime, Guid processId, string uniqueCardName, ICommand command)
        {
            EventTime = eventTime;
            ProcessId = processId;
            UniqueCardName = uniqueCardName;
            Command = command;
        }
    }
}
