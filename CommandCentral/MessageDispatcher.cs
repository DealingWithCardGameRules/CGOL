using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public sealed class MessageDispatcher : IDispatcher
    {
        private readonly IServiceProvider provider;
        private readonly IEventDispatcher eventDispatcher;

        public MessageDispatcher(IServiceProvider serviceProvider, IEventDispatcher eventDispatcher)
        {
            provider = serviceProvider ?? throw new ArgumentNullException(nameof(IServiceProvider));
            this.eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
        }

        public void Dispatch(ICommand command)
        {
            // Identify command handler
            Type commandHandlerType = typeof(ICommandHandler<>);
            Type[] commandType = { command.GetType() };
            Type genericHandlerType  = commandHandlerType.MakeGenericType(commandType);

            // Engage command handler
            dynamic handler = provider.GetService(genericHandlerType);
            handler.Handle((dynamic)command, eventDispatcher);
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
    }
}
