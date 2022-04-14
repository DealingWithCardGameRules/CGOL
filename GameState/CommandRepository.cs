using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class CommandRepository : ICommandRepositoryQueries
    {
        public IEnumerable<IUserAction> Commands => repository;
        private readonly List<IUserAction> repository;

        public CommandRepository()
        {
            repository = new List<IUserAction>();
        }

        public void Clear()
        {
            repository.Clear();
        }

        public void AddCommand(string label, ICommand command)
        {
            repository.Add(new UserCommand(label, command));
        }

        class UserCommand : IUserAction
        {
            public ICommand Command { get; }
            public string Label { get; }

            public UserCommand(string label, ICommand command)
            {
                Label = label;
                Command = command;
            }
        }
    }
}
