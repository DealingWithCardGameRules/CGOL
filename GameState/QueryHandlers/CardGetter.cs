using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class CardGetter : IQueryHandler<GetCard, ICard?>
    {
        private readonly Game game;

        public CardGetter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public ICard? Handle(GetCard query)
        {
            return game.GetCard(query.SourceId, query.CardId);
        }
    }
}
