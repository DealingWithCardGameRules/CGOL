using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole.Handlers
{
    public class PickACardHandler : IQueryHandler<PickACard, Guid?>
    {
        Random random;
        public PickACardHandler()
        {
            random = new Random();
        }

        public async Task<Guid?> Handle(PickACard query)
        {
            var index = random.Next(0, query.Selection.Length);
            return query.Selection[index].Instance;
        }
    }
}
