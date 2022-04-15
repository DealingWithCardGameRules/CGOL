﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ChangeState : ICommand
    {
        public Guid ProcessId => new Guid("5A5DC817-AF56-4CF8-8993-826BEB8EF3D2");

        public Guid Instance { get; }
        public string NewState { get; }

        public ChangeState(string newState)
        {
            Instance = Guid.NewGuid();
            NewState = newState;
        }
    }
}