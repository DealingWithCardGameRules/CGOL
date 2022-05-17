using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.Parser.Messages
{
    public class LoadCGDL : ICommand
    {
        public Guid ProcessId => new Guid("155FAB8A-61F9-4945-B8D7-12BD69182F8B");

        public Guid Instance { get; }

        public string CGDL { get; }

        public LoadCGDL(string cgdl)
        {
            Instance = Guid.NewGuid();
            CGDL = cgdl;
        }
    }
}
