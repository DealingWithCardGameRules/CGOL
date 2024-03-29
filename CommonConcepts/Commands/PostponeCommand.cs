﻿using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class PostponeCommand : ICommand
    {
        public Guid ProcessId => new Guid("85A8EA4B-4945-4F41-B3CC-C4A127F00DC9");

        public ICommand Command { get; }
        public string? Label { get; }
        public Guid Instance { get; }

        private Guid? cardRef;

        [AffectSelf]
        public Guid? SelfRef
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
                    Command.SetAffactSelfRef(value.Value);
                }
            }
        }

        [Concept(Description = "Set up a player action. If the label is not supplied, the command name is displayed for the player. If attached to a card, the action is considered temporary. Use the Play keyword to utilize.")]
        public PostponeCommand(ICommand command, string? label = null)
        {
            Instance = Guid.NewGuid();
            Command = command;
            Label = label;
        }
    }
}
