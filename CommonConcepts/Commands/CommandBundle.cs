﻿using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class CommandBundle : ICommand
    {
        public Guid ProcessId => new Guid("38AF7C74-43E7-4252-BC2C-25C7B3290425");

        public Guid Instance { get; }

        private Guid? cardRef;

        [AffectSelf] public Guid? SelfRef 
        { 
            get
            {
                return cardRef;
            }
            set
            {
                cardRef = value;
                if (value.HasValue)
                {
                    foreach (var command in Commands)
                    {
                        command.SetAffactSelfRef(value.Value);
                    }
                }
            }
        }

        [PlayCollection] public IEnumerable<string> SourceRefs => Commands.SelectMany(c => c.GetPlayFroms());
        [PlayCollection] public IEnumerable<MaybeQuery<string>> SourceRefsMaybeQueries => Commands.SelectMany(c => c.GetPlayFromMaybeQueries());

        public IEnumerable<ICommand> Commands { get; }

        [Concept(Description = "Bundle a number of commands to be distributed at the same time. Use the colon, newline-tab syntax to utilize.")]
        public CommandBundle(ICommand[] commands)
        {
            Instance = Guid.NewGuid();
            Commands = commands;
        }
    }
}
