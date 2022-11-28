using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class ResolvePermanentsHandler : ICommandHandler<ResolvePermanents>
    {
        private readonly IDispatcher dispatcher;

        public ResolvePermanentsHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ResolvePermanents command, IEventDispatcher eventDispatcher)
        {
            IAsyncEnumerable<string> collections;
            var playerIndex = (await dispatcher.Dispatch(new CurrentPlayer()))?.Index ?? 0;
            if (string.IsNullOrEmpty(command.Zone))
            {
                collections = (await dispatcher.Dispatch(new GetCollectionNames
                {
                    WithTags = new string[] { "zone" },
                    OwnedBy = playerIndex
                }))();
            }
            else
                collections = new string[] { command.Zone }.ToAsyncEnumerable();

            collections = collections.Union((await dispatcher.Dispatch(new GetCollectionNames
            {
                WithTags = new string[] { "community" }
            }))());

            await foreach (var effect in GetCommands(collections.ToEnumerable(), playerIndex))
                await dispatcher.Dispatch(effect);
        }

        public async IAsyncEnumerable<ICommand> GetCommands(IEnumerable<string> names, int playerIndex)
        {
            foreach (var name in names)
            {
                var cards = await dispatcher.Dispatch(new GetVisibleCards(name, new int[] { playerIndex }));
                await foreach (var card in cards())
                {
                    var template = await dispatcher.Dispatch(new GetTemplate(card.Template));
                    if (template == null)
                        yield break;

                    foreach (var command in template.Permanent)
                    { 
                        command.SetAffactSelfRef(card.Instance);
                        yield return command;
                    }
                }
            }
        }
    }
}
