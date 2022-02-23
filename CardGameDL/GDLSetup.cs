using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;
using dk.itu.game.msc.cgdl.GameState;

namespace dk.itu.game.msc.cgdl
{
    public class GDLSetup
    {
        private readonly Game game;
        private readonly Interpolator interpolator;
        private readonly ITimeProvider timeProvider;

        public GDLSetup(Game game, Interpolator interpolator, ITimeProvider timeProvider)
        {
            this.game = game;
            this.interpolator = interpolator;
            this.timeProvider = timeProvider;
        }

        public void AddHandlers()
        {
            interpolator.AddConcept(new CardStackDeclaredObserver(game));
            interpolator.AddConcept(new CardAddedToStackObserver(game));
            interpolator.AddConcept(new SimplyDeclareStack(timeProvider));
        }
    }
}
