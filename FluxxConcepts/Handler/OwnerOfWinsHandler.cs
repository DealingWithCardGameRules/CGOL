using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class OwnerOfWinsHandler : ICommandHandler<OwnerOfWins>
    {
        private readonly IDispatcher dispatcher;

        public OwnerOfWinsHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(OwnerOfWins command, IEventDispatcher eventDispatcher)
        {
            var zones = (await dispatcher.Dispatch(new GetCollectionNames { WithTags = new[] { "zone", "keepers" } }))();
            var keepers = string.Join(",", command.Keepers);

            await foreach (var zone in zones)
            {
                if (await dispatcher.Dispatch(new HasKeepers(keepers, zone)))
                {
                    var owner = await dispatcher.Dispatch(new GetCollectionOwnerIndex(zone));
                    if (owner.HasValue)
                        await dispatcher.Dispatch(new Win(owner.Value));
                }
            }
        }
    }
}
