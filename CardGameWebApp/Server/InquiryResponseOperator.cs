using System;
using System.Collections.Generic;

namespace CardGameWebApp.Server
{
    public class InquiryResponseOperator
    {
        private readonly Dictionary<Guid, IPremonition> clients;

        public InquiryResponseOperator()
        {
            clients = new Dictionary<Guid, IPremonition>();
        }

        public void Expect<T>(Guid correspondanceId, Action<T> action)
        {
            clients[correspondanceId] = new Premonition<T>(action);
        }

        public void Redeem(Guid correspondenceId, object result)
        {
            if (clients.ContainsKey(correspondenceId))
            {
                clients[correspondenceId].Redeem(result);
                clients.Remove(correspondenceId);
            }
        }

        interface IPremonition
        {
            void Redeem(object result);
        }

        class Premonition<T> : IPremonition
        {
            private readonly Action<T> action;

            public Premonition(Action<T> action)
            {
                this.action = action;
            }

            public void Redeem(object result)
            {
                if (result is null && Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    action.Invoke(default);
                }
                else if (result is not T)
                {
                    throw new ArgumentException($"Argument type {result.GetType().Name} does not match expected value {typeof(T).Name}", nameof(result));
                }
                else
                {
                    action.Invoke((T)result);
                }
            }
        }
    }
}
