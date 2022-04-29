using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class ResolvePermanentsHandler : ICommandHandler<ResolvePermanents>
    {
        private readonly IDispatcher dispatcher;

        public ResolvePermanentsHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(ResolvePermanents command, IEventDispatcher eventDispatcher)
        {
            IEnumerable<string> collections;
            var playerIndex = dispatcher.Dispatch(new CurrentPlayer())?.Index ?? 0;
            if (string.IsNullOrEmpty(command.Zone))
            {
                collections = dispatcher.Dispatch(new GetCollectionNames
                {
                    WithTags = new string[] { "zone" },
                    OwnedBy = playerIndex
                });
            }
            else
                collections = new string[] { command.Zone };

            collections = collections.Union(dispatcher.Dispatch(new GetCollectionNames
            {
                WithTags = new string[] { "community" }
            }));

            foreach (var effect in GetCommands(collections, playerIndex))
                dispatcher.Dispatch(effect);
        }

        public IEnumerable<ICommand> GetCommands(IEnumerable<string> names, int playerIndex)
        {
            foreach (var name in names)
            {
                var cards = dispatcher.Dispatch(new GetVisibleCards(name, new int[] { playerIndex }));
                foreach (var card in cards)
                {
                    var template = dispatcher.Dispatch(new GetTemplate(card.Template));
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
