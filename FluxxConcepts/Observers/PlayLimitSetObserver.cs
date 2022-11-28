using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Events;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Observers
{
    public class PlayLimitSetObserver : IEventObserver<PlayLimitSet>
    {
        private readonly PlayerCounter drawCounter;

        public PlayLimitSetObserver(PlayerCounter playCounter)
        {
            this.drawCounter = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
        }

        public async Task Invoke(PlayLimitSet @event)
        {
            drawCounter.SetLimit(@event.Limit);
        }
    }
}
