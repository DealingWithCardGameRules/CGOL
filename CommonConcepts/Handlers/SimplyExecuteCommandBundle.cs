using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyExecuteCommandBundle : ICommandHandler<CommandBundle>
    {
        private readonly IDispatcher dispatcher;

        public SimplyExecuteCommandBundle(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(CommandBundle command, IEventDispatcher eventDispatcher)
        {
            foreach (var cmd in command.Commands)
            {
                if (command.SelfRef.HasValue)
                    cmd.SetAffactSelfRef(command.SelfRef.Value);
                await dispatcher.Dispatch(cmd);
            }
        }
    }
}
