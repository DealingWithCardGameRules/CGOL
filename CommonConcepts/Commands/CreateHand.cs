using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateHand : ICommand
    {
        public Guid ProcessId => new Guid("F42D3FDC-048B-462A-8EC9-274A33F18DF5");

        public Guid HandId { get; }

        public CreateHand(Guid handId)
        {
            HandId = handId;
        }
    }
}
