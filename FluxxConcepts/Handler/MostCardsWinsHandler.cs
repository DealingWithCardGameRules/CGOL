using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using System.Linq;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class MostCardsWinsHandler : ICommandHandler<MostCardsWins>
    {
        private readonly CardCounter cardCounter;
        private readonly IDispatcher dispatcher;

        public MostCardsWinsHandler(CardCounter cardCounter, IDispatcher dispatcher)
        {
            this.cardCounter = cardCounter ?? throw new System.ArgumentNullException(nameof(cardCounter));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(MostCardsWins command, IEventDispatcher eventDispatcher)
        {
            var counts = cardCounter.Count(command.Tags.ToArray());
            var maxCount = counts.Values.Max();
            if (maxCount < command.MinCount)
                return;

            if (counts.Values.Count(v => v == maxCount) == 1)
            {
                var collection = counts.Single(c => c.Value == maxCount).Key;
                var owner = dispatcher.Dispatch(new GetCollectionOwnerIndex(collection));
                if (owner.HasValue)
                    dispatcher.Dispatch(new Win(owner.Value));
            }
        }
    }
}
