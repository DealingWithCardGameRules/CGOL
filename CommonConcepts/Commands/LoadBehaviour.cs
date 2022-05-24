﻿using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.Common.Commands
{
    public class LoadBehaviour : ICommand
    {
        public Guid ProcessId => new Guid("E372E8CC-661E-40A0-9039-AA3F379A1A78");
        public Guid Instance { get; }
        public string AssemblyName { get; }
        public string? SetupClass { get; }

        [Concept(Description = "Load handlers via a .net assembly name, then instantitate and invoke setup for a class inheriting from IPluginSetup. If no setup class is defined, the first public class inherting from IPluginSetup is used.")]
        public LoadBehaviour(string assemblyName, string setupClass = null)
        {
            Instance = Guid.NewGuid();
            AssemblyName = assemblyName;
            SetupClass = setupClass;
        }
    }
}
