using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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
