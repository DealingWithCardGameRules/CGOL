﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl
{
    public class Interpolator : IServiceProvider
    {
        public Dictionary<Type, object> conceptHandlers;
        public HashSet<Type> supported;

        public Interpolator()
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

        public bool Supports<T>(T _) => supported.Contains(typeof(T));

        public void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand
        {
            Add(commandHandler);
            supported.Add(typeof(T));
        }

        public void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>
        {
            Add(queryHandler);
            supported.Add(typeof(T));
        }

        public void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent
        {
            Add(eventObserver);
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
            Remove(eventObserver);
            supported.Remove(typeof(T));
        }

        private void Add(object obj)
        {
            if (conceptHandlers.ContainsKey(obj.GetType()))
                throw new DuplicateConceptException(obj.GetType());

            conceptHandlers[obj.GetType()] = obj;
        }

        private void Remove(object obj)
        {
            if (conceptHandlers.ContainsKey(obj.GetType()))
                conceptHandlers.Remove(obj.GetType());
        }

    }
}