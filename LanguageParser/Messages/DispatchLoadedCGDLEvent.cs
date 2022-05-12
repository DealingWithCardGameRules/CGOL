using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.LanguageParser.Messages
{
    public class DispatchLoadedCGDLEvent : IEventObserver<CGDLLoaded>
    {
        private readonly IDispatcher dispatcher;

        public DispatchLoadedCGDLEvent(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Invoke(CGDLLoaded @event)
        {
            foreach (var command in @event.Commands)
            {
                dispatcher.Dispatch(command);
            }
        }
    }
}
