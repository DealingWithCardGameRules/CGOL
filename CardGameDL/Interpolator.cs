using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl
{
    public class Interpreter : IInterpreter
    {
        public Dictionary<Type, object> conceptHandlers;
        public HashSet<Type> supported;

        public IEnumerable<Type> SupportedTypes => supported;

        public Interpreter()
        {
            conceptHandlers = new Dictionary<Type, object>();
            supported = new HashSet<Type>();
        }

        public object GetService(Type serviceType)
        {
            if (!conceptHandlers.ContainsKey(serviceType))
                throw new UnknownConceptException(serviceType);

            return conceptHandlers[serviceType];
        }
        public T GetService<T>()
        {
            if (!conceptHandlers.ContainsKey(typeof(T)))
                throw new UnknownConceptException(typeof(T));

            return (T) conceptHandlers[typeof(T)];
        }

        public bool Supports(object type)
        {
            if (type == null)
                return false;
            return supported.Contains(type.GetType());
        }

        public bool Supports<T>() => supported.Contains(typeof(T));

        public void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand
        {
            Add<ICommandHandler<T>>(commandHandler);
            supported.Add(typeof(T));
        }

        public void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>
        {
            Add<IQueryHandler<T, TResult>>(queryHandler);
            supported.Add(typeof(T));
        }

        public void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent
        {
            if (!conceptHandlers.ContainsKey(typeof(IEventObserver<T>)))
                conceptHandlers[typeof(IEventObserver<T>)] = new EventObserverList<T>();

            if (conceptHandlers[typeof(IEventObserver<T>)] is EventObserverList<T> list)
                list.EventObservers.Add(eventObserver);

            supported.Add(typeof(T));
        }

        public void RemoveConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand
        {
            Remove(commandHandler);
            supported.Remove(typeof(T));
        }

        public void RemoveConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>
        {
            Remove(queryHandler);
            supported.Remove(typeof(T));
        }

        public void RemoveConcept<T>(IEventObserver<T> eventObserver) where T : IEvent
        {
            if (conceptHandlers.ContainsKey(typeof(IEventObserver<T>)))
            {
                if (conceptHandlers[typeof(IEventObserver<T>)] is EventObserverList<T> list)
                {
                    list.EventObservers.Remove(eventObserver);
                    if (!(list.EventObservers.Any()))
                    {
                        conceptHandlers.Remove(typeof(IEventObserver<T>));
                        supported.Remove(typeof(T));
                    }
                }
                else
                {
                    Remove(eventObserver);
                    supported.Remove(typeof(T));
                }
            }            
        }

        private void Add<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            conceptHandlers[typeof(T)] = obj;
        }

        private void Remove<T>(T _)
        {
            if (conceptHandlers.ContainsKey(typeof(T)))
                conceptHandlers.Remove(typeof(T));
        }

        public Type? ResolveCommand(string concept)
        {
            return supported
                .Where(t => typeof(ICommand).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name.Equals(concept));
        }

        public Type? ResolveQuery<TReturn>(string concept)
        {
            return supported
                .Where(t => typeof(IQuery<TReturn>).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name.Equals(concept));
        }

        public Type? Resolve<TConcept>(string concept)
        {
            return supported
                .Where(t => typeof(TConcept).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name.Equals(concept));
        }
    }

    public class EventObserverList<T> : IEventObserver<T> where T : IEvent
    {
        public List<IEventObserver<T>> EventObservers { get; }
        public EventObserverList()
        {
            EventObservers = new List<IEventObserver<T>>();
        }

        public void Invoke(T @event)
        {
            foreach (var observer in EventObservers)
                observer.Invoke(@event);
        }
    }
}
