﻿using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DealAll : ICommand
    {
        public Guid ProcessId => new Guid("4CE38B0C-F8BB-4F62-B548-E2D6D4FCA611");

        public Guid Instance { get; }
        public string Source { get; }
        public int Cards { get; }

        public DealAll(string source, int cards = 1)
        {
            Instance = Guid.NewGuid();
            Source = source;
            Cards = cards;
        }
    }
}
