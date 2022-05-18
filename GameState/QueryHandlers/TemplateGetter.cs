using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class TemplateGetter : IQueryHandler<GetTemplate, ICardTemplate?>
    {
        private readonly Library library;

        internal TemplateGetter(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public ICardTemplate? Handle(GetTemplate query)
        {
            return library.GetCardTemplate(query.Template);
        }
    }
}
