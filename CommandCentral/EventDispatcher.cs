using System;

namespace dk.itu.game.msc.cgol.Distribution
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IInterpreter interpreter;

        public EventDispatcher(IInterpreter interpreter)
        {
            this.interpreter = interpreter ?? throw new ArgumentNullException(nameof(interpreter));
        }

        public void Dispatch(IEvent @event)
        {
            if (!interpreter.Supports(@event))
            {
                Console.WriteLine($"Warning event ignored! No observers for event {@event.GetType().Name}.");
                return;
            }

            // Identify event observer
            Type eventObserverType = typeof(IEventObserver<>);
            Type[] eventType = { @event.GetType() };
            Type genericObserverType = eventObserverType.MakeGenericType(eventType);

            // Invoke event observer
            dynamic observer = interpreter.GetService(genericObserverType);
            observer.Invoke((dynamic)@event);
        }
    }
}
