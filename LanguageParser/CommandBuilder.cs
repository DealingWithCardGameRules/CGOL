using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    internal class CommandBuilder
    {
        public CommandBuilder(Type type)
        {
            if (type.GetInterface("ICommand") == null)
                throw new Exception("The type must inherit from ICommand");
        }
    }
}
