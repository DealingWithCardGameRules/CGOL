﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class StateTransitionDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string State { get; }

        public StateTransitionDeclared(DateTime eventTime, Guid processId, string state)
        {
            EventTime = eventTime;
            ProcessId = processId;
            State = state;
        }
    }
}