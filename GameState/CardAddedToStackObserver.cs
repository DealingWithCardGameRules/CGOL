using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class CardAddedToStackObserver : IEventObserver<CardAddedToStack>
    {
        private readonly Game game;

        public CardAddedToStackObserver(Game game)
        {
            this.game = game;
        }

        public void Invoke(CardAddedToStack @event)
        {
            game.AddCard(@event.StackId, @event.Card);
        }
    }
}
