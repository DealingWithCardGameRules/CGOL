﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CGDLLoaded : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public ICommand[] Commands { get; }

        public CGDLLoaded(DateTime eventTime, Guid processId, IEnumerable<ICommand> commands)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Commands = commands.ToArray();
        }
    }
}
