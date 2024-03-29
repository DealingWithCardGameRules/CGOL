﻿using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class Start : ICommand
    {
        public Guid ProcessId => new Guid("F8DCE217-1137-4975-9B0B-2D2701E5E5FA");

        public Guid Instance { get; }

        [Concept(Description = "Start the turn for the current player.")]
        public Start()
        {
            Instance = Guid.NewGuid();
        }
    }
}
