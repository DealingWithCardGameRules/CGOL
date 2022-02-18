using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider provider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            provider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void Dispatch(IEvent @event)
        {
            // Identify event observer
            Type eventObserverType = typeof(IEventObserver<>);
            Type[] eventType = { @event.GetType() };
            Type genericObserverType = eventObserverType.MakeGenericType(eventType);

            // Invoke event observer
            dynamic observer = provider.GetService(genericObserverType);
            observer.Invoke((dynamic)@event);
        }
    }
}
