using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyExecuteCommandBundle : ICommandHandler<CommandBundle>
    {
        private readonly IDispatcher dispatcher;

        public SimplyExecuteCommandBundle(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(CommandBundle command, IEventDispatcher eventDispatcher)
        {
            foreach (var cmd in command.Commands)
            {
                if (command.SelfRef.HasValue)
                    cmd.SetAffactSelfRef(command.SelfRef.Value);
                dispatcher.Dispatch(cmd);
            }
        }
    }
}
