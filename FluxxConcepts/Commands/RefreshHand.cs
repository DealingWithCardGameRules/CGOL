using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class RefreshHand : ICommand
    {
        public Guid ProcessId => new Guid("74BB3134-FEC3-4B99-B3F0-B53253F1BCC1");

        public Guid Instance { get; }
        public int? FixedReward { get; }
        public string RewardCollection { get; }
        public string DiscardCollection { get; }

        [Concept(Description = "Current player discards hand and is dealt a number of cards. The number will be fixedReward if set, otherwise the same amount as discarded.")]
        public RefreshHand(string rewardCollection, string discardCollection, int fixedReward = 0)
        {
            Instance = Guid.NewGuid();
            if (fixedReward > 0)
                FixedReward = fixedReward;
            RewardCollection = rewardCollection;
            DiscardCollection = discardCollection;
        }
    }
}
