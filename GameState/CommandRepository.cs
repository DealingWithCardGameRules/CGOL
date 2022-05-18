using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CommandRepository : ICommandRepositoryQueries
    {
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

        public IEnumerable<IUserAction> GetCommands(int? _)
        {
            return repository;
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
