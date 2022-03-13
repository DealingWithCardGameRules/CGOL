using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareCard : ICommandHandler<CreateCard>
    {
        public void Handle(CreateCard command, IEventDispatcher eventDispatcher)
        {
            // TODO
        }
    }
}
