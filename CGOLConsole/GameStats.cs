using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole
{
    internal class GameStats
    {
        List<StatEntity> stats;
        public int? playerWon;
        public bool gameOver = false;
        private readonly IQueryDispatcher dispatcher;

        public double AvgPlayer => stats.Average(s => s.players);
        public double AvgCards => stats.Average(s => s.cards);
        public double AvgDecks => stats.Average(s => s.decks);
        public double AvgActions => stats.Average(s => s.actions);
        public double AvgOptions => stats.Average(s => s.options);

        public GameStats(IQueryDispatcher dispatcher)
        {
            stats = new List<StatEntity>();
            this.dispatcher = dispatcher;
        }

        public async Task AddStats()
        {
            var collections = (await dispatcher.Dispatch(new GetCollectionNames()))();
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            var actions = (await dispatcher.Dispatch(new GetAvailableActions(player.Index)))().Select(a => a.Command);
            stats.Add(new StatEntity
            {
                currentPlayer = player.Index,
                players = await dispatcher.Dispatch(new GetNumberOfPlayers()),
                decks = await collections.CountAsync(),
                cards = await collections.SumAwaitAsync(async c => await dispatcher.Dispatch(new CardCount(c))),
                actions = await actions.CountAsync(),
                options = 0//await actions.CountAwaitAsync(async a => await a.GetChoices<Guid>().CountAsync())
            });;
        }
    }

    internal class StatEntity
    {
        public int currentPlayer;
        public int players;
        public int cards;
        public int decks;
        public int actions;
        public int options;
    }
}
