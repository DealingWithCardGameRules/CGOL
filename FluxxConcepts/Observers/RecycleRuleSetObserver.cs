using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Events;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Observers
{
    public class RecycleRuleSetObserver : IEventObserver<RecycleRuleSet>
    {
        private readonly RecycleRules recycleRules;

        public RecycleRuleSetObserver(RecycleRules recycleRules)
        {
            this.recycleRules = recycleRules ?? throw new System.ArgumentNullException(nameof(recycleRules));
        }

        public void Invoke(RecycleRuleSet @event)
        {
            recycleRules.SetRule(@event.From, @event.To);
        }
    }
}
