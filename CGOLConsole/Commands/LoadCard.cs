using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace CGOLConsole.Commands
{
    public class LoadCard : ICommand
    {
        public Guid ProcessId => new Guid("036F44A3-BCB9-433A-9017-AF109C18469B");

        public Guid Instance { get; set; }
        public string File { get; }

        [Concept(Description = "Load a text file and distribute it to the language parser.")]
        public LoadCard(string file)
        {
            Instance = Guid.NewGuid();
            File = file;
        }
    }
}
