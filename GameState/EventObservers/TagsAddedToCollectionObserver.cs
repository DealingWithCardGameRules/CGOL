using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class TagsAddedToCollectionObserver : IEventObserver<TagsAddedToCollection>
    {
        private readonly Game game;

        public TagsAddedToCollectionObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(TagsAddedToCollection @event)
        {
            foreach (var tag in @event.Tags)
                game.AddTag(@event.Collection, tag);
        }
    }
}
