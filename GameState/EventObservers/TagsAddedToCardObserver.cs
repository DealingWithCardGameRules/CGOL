using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class TagsAddedToTemplateObserver : IEventObserver<TagsAddedToTemplate>
    {
        private readonly Library library;

        public TagsAddedToTemplateObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(TagsAddedToTemplate @event)
        {
            library.AddTags(@event.Template, @event.Tags);
        }
    }
}
