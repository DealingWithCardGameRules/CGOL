using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Common
{
    public class Maybe<ValueType>
    {
        private readonly IEnumerable<ValueType> values;

        public Maybe(ValueType value) => values = new[] { value };

        public Maybe() => values = new ValueType[0];

        public bool HasValue() => values.Any();

        public ValueType ValueOrDefault(ValueType defaultValue) =>
            values.DefaultIfEmpty(defaultValue).Single();

        public void Apply(Action<ValueType> action)
        {
            if (HasValue())
                action.Invoke(values.Single());
        }

        public async Task Apply(Func<ValueType, Task> func)
        {
            if (HasValue())
                await func(values.Single());
        }

        public T Apply<T>(Func<ValueType, T> func, ValueType defaultValue)
        {
            return func(ValueOrDefault(defaultValue));
        }

        public async Task<T> Apply<T>(Func<ValueType, Task<T>> func, ValueType defaultValue)
        {
            return await func(ValueOrDefault(defaultValue));
        }
    }
}
