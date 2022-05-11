using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IInterpreter : IServiceProvider
    {
        IEnumerable<Type> SupportedTypes { get; }
        bool Supports(object type);
        bool Supports<T>();
        Type? ResolveCommand(string concept);
        Type? ResolveQuery<TReturn>(string concept);
        void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        void RemoveConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void RemoveConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void RemoveConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        T GetService<T>();
    }
}
