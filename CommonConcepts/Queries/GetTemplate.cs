using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetTemplate : IQuery<ICardTemplate?>
    {
        public string Template { get; }
        
        public GetTemplate(string template)
        {
            Template = template;
        }
    }
}
