using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class DiscardCardHandler : ICommandHandler<DiscardCard>
	{
		private readonly IDispatcher dispatcher;

		public DiscardCardHandler(IDispatcher dispatcher)
		{
			this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
		}

		public async Task Handle(DiscardCard command, IEventDispatcher eventDispatcher)
		{
			var playerIndex = command.PlayerIndex ?? await dispatcher.Dispatch(new GetCollectionOwnerIndex(command.From));
			if (!playerIndex.HasValue)
				throw new Exception($"No player specified and no owner found for collection \"{command.From}\"");
			
			var cards = await dispatcher.Dispatch(new GetCards(command.From));
			var card = await dispatcher.Dispatch(new PickACard(cards().ToEnumerable(), playerIndex.Value));

			if (card == null)
				throw new Exception("No card selected.");

			await dispatcher.Dispatch(new PlaceIn(command.To, card));
		}
	}
}
