using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
