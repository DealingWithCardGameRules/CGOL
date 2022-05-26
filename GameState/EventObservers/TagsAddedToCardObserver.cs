using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class TagsAddedToTemplateObserver : IEventObserver<TagsAddedToTemplate>
    {
        private readonly Library library;

        internal TagsAddedToTemplateObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(TagsAddedToTemplate @event)
        {
            library.AddTags(@event.Template, @event.Tags);
        }
    }
}
