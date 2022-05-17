using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IInterpreter : IServiceProvider
    {
        IEnumerable<Type> SupportedTypes { get; }
        bool Supports(object type);
        bool Supports<T>();
        Type? Resolve<TConcept>(string concept);
        void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        void RemoveConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        void RemoveConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        void RemoveConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        T GetService<T>();
    }
}
