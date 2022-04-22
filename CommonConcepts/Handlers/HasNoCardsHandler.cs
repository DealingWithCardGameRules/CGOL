using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class HasNoCardsHandler : IQueryHandler<HasNoCards, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public HasNoCardsHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public bool Handle(HasNoCards query)
        {
            return !dispatcher.Dispatch(new HasCards(query.Collection));
        }
    }
}
