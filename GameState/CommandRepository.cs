using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class CommandRepository
    {
        private List<ICommand> repository;

        public CommandRepository()
        {
            repository = new List<ICommand>();
        }


    }
}
