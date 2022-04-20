using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ShuffleInto : ICommand
    {
        public Guid ProcessId => new Guid("CD1D4332-1807-4C19-AEFA-600ADFB24EAA");

        public Guid Instance { get; }
        public string From { get; }
        public string To { get; }

        public ShuffleInto(string from, string to)
        {
            Instance = Guid.NewGuid();
            From = from;
            To = to;
        }
    }
}
