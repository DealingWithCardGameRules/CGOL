using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class CommandRepository
    {
        public IEnumerable<IUserCommand> Commands => repository;
        private readonly List<IUserCommand> repository;

        public CommandRepository()
        {
            repository = new List<IUserCommand>();
        }

        public void AddCommand(string label, ICommand command)
        {
            repository.Add(new UserCommand
            {
                Command = command,
                Label = label
            });
        }

        class UserCommand : IUserCommand
        {
            public ICommand Command { get; set; }
            public string Label { get; set; }
        }
    }
}
