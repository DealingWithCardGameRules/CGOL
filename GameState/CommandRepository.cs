using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class CommandRepository
    {
        public IEnumerable<ICommand> Commands => repository;
        private readonly List<ICommand> repository;

        public CommandRepository()
        {
            repository = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            repository.Add(command);
        }
    }
}
