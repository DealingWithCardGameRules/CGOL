using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IInterpolator : IServiceProvider
    {
        bool Supports(object type);
        bool Supports<T>();
        Type? ResolveCommand(string concept);
        Type? ResolveQuery(string concept);

        void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        void RemoveConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void RemoveConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void RemoveConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
    }
}
