using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetAvailableAction : IQuery<ICommand?>
    {
        public Guid Instance { get; set; }
        public int? PlayerIndex { get; }

        [Concept(Description = "Get command with specific instance value amoung available player actions.")]
        public GetAvailableAction(Guid instance, int? playerIndex = null)
        {
            Instance = instance;
            PlayerIndex = playerIndex;
        }
    }
}
