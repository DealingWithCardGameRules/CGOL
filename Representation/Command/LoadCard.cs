using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.Representation.Command
{
    public class LoadCard : ICommand
    {
        public Guid ProcessId => new Guid("EB31D72C-772E-481B-8ACA-5C18AD2DAD39");

        public Guid Instance { get; set; }
        public string File { get; }

        public LoadCard(string file)
        {
            Instance = Guid.NewGuid();
            File = file;
        }
    }
}
