using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Events;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Observers
{
    public class DrawLimitSetObserver : IEventObserver<DrawLimitSet>
    {
        private readonly PlayerCounter drawCounter;

        public DrawLimitSetObserver(PlayerCounter drawCounter)
        {
            this.drawCounter = drawCounter ?? throw new System.ArgumentNullException(nameof(drawCounter));
        }

        public async Task Invoke(DrawLimitSet @event)
        {
            drawCounter.SetLimit(@event.DrawLimit);
        }
    }
}
