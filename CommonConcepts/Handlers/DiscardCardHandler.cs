using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
	public class DiscardCardHandler : ICommandHandler<DiscardCard>
	{
		private readonly IDispatcher dispatcher;

		public DiscardCardHandler(IDispatcher dispatcher)
		{
			this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
		}

		public void Handle(DiscardCard command, IEventDispatcher eventDispatcher)
		{
			var card = dispatcher.Dispatch(new PickACard("player", command.PlayerIndex));
			if (card != null)
				dispatcher.Dispatch(new PlaceIn("discard pile", card));
		}
	}
}
