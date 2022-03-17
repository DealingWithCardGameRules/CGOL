using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;

namespace dk.itu.game.msc.cgdl.GameState.CommandHandlers
{
    public class PostponedCommandHandler : ICommandHandler<PostponedCommand>
    {
        private readonly CommandRepository repository;

        public PostponedCommandHandler(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public void Handle(PostponedCommand command, IEventDispatcher eventDispatcher)
        {
            repository.AddCommand(command.Command);
        }
    }
}
