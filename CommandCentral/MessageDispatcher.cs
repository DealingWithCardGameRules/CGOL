using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    internal sealed class MessageDispatcher : IDispatcher, IEventDispatcher
    {
        private readonly IServiceProvider provider;

        public MessageDispatcher(IServiceProvider serviceProvider)
        {
            provider = serviceProvider ?? throw new ArgumentNullException(nameof(IServiceProvider));
        }

        public void Dispatch(ICommand command)
        {
            // Identify command handler
            Type commandHandlerType = typeof(ICommandHandler<>);
            Type[] commandType = { command.GetType() };
            Type genericHandlerType  = commandHandlerType.MakeGenericType(commandType);

            // Engage command handler
            dynamic handler = provider.GetService(genericHandlerType);
            handler.Handle((dynamic)command, this);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            // Identify query handler
            Type queryHandlerType = typeof(IQueryHandler<,>);
            Type[] queryType = { query.GetType(), typeof(T) }; 
            Type genericHandlerType = queryHandlerType.MakeGenericType(queryType);

            // Engage query handler
            dynamic handler = provider.GetService(genericHandlerType);
            T result = handler.Handle((dynamic)query);
            return result;
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
