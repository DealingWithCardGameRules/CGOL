using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class ReshuffleRuleSetObserver : IEventObserver<ReshuffleRuleSet>
    {
        private readonly ReshuffleRules reshuffleRules;

        internal ReshuffleRuleSetObserver(ReshuffleRules ReshuffleRules)
        {
            reshuffleRules = ReshuffleRules ?? throw new System.ArgumentNullException(nameof(ReshuffleRules));
        }

        public void Invoke(ReshuffleRuleSet @event)
        {
            reshuffleRules.SetRule(@event.From, @event.To);
        }
    }
}
