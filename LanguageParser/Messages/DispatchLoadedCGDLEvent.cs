using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.Parser.Messages
{
    public class DispatchLoadedCGOLEvent : IEventObserver<CGOLLoaded>
    {
        private readonly IDispatcher dispatcher;

        public DispatchLoadedCGOLEvent(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Invoke(CGOLLoaded @event)
        {
            foreach (var command in @event.Commands)
            {
                dispatcher.Dispatch(command);
            }
        }
    }
}
