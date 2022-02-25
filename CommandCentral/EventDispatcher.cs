using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IInterpolator interpolator;

        public EventDispatcher(IInterpolator interpolator)
        {
            this.interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
        }

        public void Dispatch(IEvent @event)
        {
            if (!interpolator.Supports(@event))
            {
                Console.WriteLine($"Warning event ignored! No observers for event {@event.GetType().Name}.");
                return;
            }

            // Identify event observer
            Type eventObserverType = typeof(IEventObserver<>);
            Type[] eventType = { @event.GetType() };
            Type genericObserverType = eventObserverType.MakeGenericType(eventType);

            // Invoke event observer
            dynamic observer = interpolator.GetService(genericObserverType);
            observer.Invoke((dynamic) @event);
        }
    }
}
