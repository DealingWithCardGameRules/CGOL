using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Events;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Observers
{
    public class PlayLimitSetObserver : IEventObserver<PlayLimitSet>
    {
        private readonly PlayerCounter drawCounter;

        public PlayLimitSetObserver(PlayerCounter playCounter)
        {
            this.drawCounter = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
        }

        public void Invoke(PlayLimitSet @event)
        {
            drawCounter.SetLimit(@event.Limit);
        }
    }
}
