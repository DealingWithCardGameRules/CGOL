using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState
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

        public async Task<Func<IAsyncEnumerable<IUserAction>>> GetCommands(int? _)
        {
            return () => repository.ToAsyncEnumerable();
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
