using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.Common
{
    public class MaybeChoice <ValueType>
    {
        private readonly IEnumerable<ValueType> values;
        private readonly IQuery<IEnumerable<ValueType>>? optionsQuery;
        private IEnumerable<ValueType> choices;

        public MaybeChoice(ValueType value)
        {
            values = new[] { value };
            choices = new ValueType[0];
        }

        public MaybeChoice(IQuery<IEnumerable<ValueType>> query)
        {
            optionsQuery = query ?? throw new ArgumentNullException(nameof(query));
            values = new ValueType[0];
            choices = new ValueType[0];
        }

        public bool HasValue => values.Any();
        public bool HasChosen => choices.Any();

        public void Choose(Func<IEnumerable<ValueType>, ValueType> chooser, IQueryDispatcher dispatcher)
        {
            choices = new[] { chooser(GetOptions(dispatcher)) };
        }

        public void Choose(ValueType value)
        {
            choices = new[] { value };
        }

        public ValueType ValueOrChoice(Func<IEnumerable<ValueType>, ValueType> chooser, IQueryDispatcher dispatcher)
        {
            if (HasValue)
                return values.Single();
            else if (HasChosen)
            {
                if (GetOptions(dispatcher).Contains(choices.Single()))
                    return choices.Single();
            }

            return chooser(GetOptions(dispatcher));
        }

        public void ClearChoice()
        {
            choices = new ValueType[0];
        }

        private IEnumerable<ValueType> GetOptions(IQueryDispatcher dispatcher)
        {
            if (optionsQuery != null)
                return dispatcher.Dispatch(optionsQuery);
            return new ValueType[0];
        }
    }
}
