﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class PlayerDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public IPlayer Player { get; }

        public PlayerDeclared(DateTime eventTime, Guid processId, IPlayer player)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Player = player;
        }
    }
}