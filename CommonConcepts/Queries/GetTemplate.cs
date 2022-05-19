using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetTemplate : IQuery<ICardTemplate?>
    {
        public string Template { get; }

        [Concept(Description = "Try to get the template for a card based on the unique card name.")]
        public GetTemplate(string template)
        {
            Template = template;
        }
    }
}
