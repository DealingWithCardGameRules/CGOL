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

        public void AddStats()
        {
            var collections = dispatcher.Dispatch(new GetCollectionNames());
            var player = dispatcher.Dispatch(new CurrentPlayer());
            var actions = dispatcher.Dispatch(new GetAvailableActions(player.Index)).Select(a => a.Command);
            stats.Add(new StatEntity
            {
                currentPlayer = player.Index,
                players = dispatcher.Dispatch(new GetNumberOfPlayers()),
                decks = collections.Count(),
                cards = collections.Sum(c => dispatcher.Dispatch(new CardCount(c))),
                actions = actions.Count(),
                options = actions.Sum(a => a.GetChoices<string>().Sum(c => c.Choices(dispatcher).Count()))
            });
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
