using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.Parser.Messages
{
    public class LoadCGOL : ICommand
    {
        public Guid ProcessId => new Guid("155FAB8A-61F9-4945-B8D7-12BD69182F8B");

        public Guid Instance { get; }

        public string CGOL { get; }

        public LoadCGOL(string cgol)
        {
            Instance = Guid.NewGuid();
            CGOL = cgol;
        }
    }
}
