using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgdl.Representation.Handlers
{
    public class PickACardHandler : IQueryHandler<PickACard, Guid?>
    {
        private const int secondsToMiliseconds = 100;
        private readonly IUserEnquirer enquirer;

        public PickACardHandler(IUserEnquirer enquirer)
        {
            this.enquirer = enquirer ?? throw new ArgumentNullException(nameof(enquirer));
        }

        public Guid? Handle(PickACard query)
        {
            Guid? cardId = null;
            Task.Run(() => cardId = enquirer.SelectCard(query.Player, query.Collection, query.RequiredTags, query.Required))
                .Wait(query.TimeoutLimitSeconds * secondsToMiliseconds);
            return cardId;
        }
    }
}
