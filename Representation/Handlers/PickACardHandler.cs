using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgdl.Representation.Handlers
{
    public class PickACardHandler : IQueryHandler<PickACard, Guid?>
    {
        private readonly Func<PickACard, Guid> askPlayer;

        public PickACardHandler(Func<PickACard, Guid> askPlayer)
        {
            this.askPlayer = askPlayer ?? throw new ArgumentNullException(nameof(askPlayer));
        }

        public Guid? Handle(PickACard query)
        {
            Guid? returnValue = null;
            new Task(() => returnValue = askPlayer(query)).Wait(query.TimeoutLimitSeconds * 100);
            return returnValue;
        }
    }
}
