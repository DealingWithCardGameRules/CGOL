using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Common
{
    public class MaybeChoice <ValueType>
    {
        private readonly IEnumerable<ValueType> values;
        private readonly IQuery<Func<IAsyncEnumerable<ValueType>>>? optionsQuery;
        private IEnumerable<ValueType> choices;

        public MaybeChoice(ValueType value)
        {
            values = new[] { value };
            choices = new ValueType[0];
        }

        public MaybeChoice(IQuery<Func<IAsyncEnumerable<ValueType>>> query)
        {
            optionsQuery = query ?? throw new ArgumentNullException(nameof(query));
            values = new ValueType[0];
            choices = new ValueType[0];
        }

        public bool HasValue => values.Any();
        public bool HasChosen => choices.Any();

        public async Task Choose(Func<IEnumerable<ValueType>, Task<ValueType>> chooser, IQueryDispatcher dispatcher)
        {
            choices = new[] { await chooser(await GetOptions(dispatcher)) };
        }

        public void Choose(ValueType value)
        {
            choices = new[] { value };
        }

        public async Task<ValueType> ValueOrChoice(Func<IEnumerable<ValueType>, Task<ValueType>> chooser, IQueryDispatcher dispatcher)
        {
            if (HasValue)
                return values.Single();
            else if (HasChosen)
            {
                if ((await GetOptions(dispatcher)).Contains(choices.Single()))
                    return choices.Single();
            }

            return await chooser(await GetOptions(dispatcher));
        }

        public async IAsyncEnumerable<ValueType> Choices(IQueryDispatcher dispatcher)
        {
            foreach (var choises in await GetOptions(dispatcher))
                yield return choises;
        }

        public void ClearChoice()
        {
            choices = new ValueType[0];
        }

        private async Task<IEnumerable<ValueType>> GetOptions(IQueryDispatcher dispatcher)
        {
            if (optionsQuery != null)
                return (await dispatcher.Dispatch(optionsQuery))().ToEnumerable();
            return new ValueType[0];
        }
    }

    public static class MaybeChoiceHelper
    {
        public static async IAsyncEnumerable<MaybeChoice<T>> GetChoices<T>(this ICommand command)
        {
            foreach (var property in command.GetType().GetProperties())
            {
                if (typeof(MaybeChoice<T>).IsAssignableFrom(property.PropertyType))
                {
                    yield return (MaybeChoice<T>)property.GetValue(command);
                }
                else if (property.PropertyType is ICommand)
                {
                    await foreach (var item in ((ICommand)property.GetValue(command)).GetChoices<T>())
                    {
                        yield return item;
                    }
                }
                else if (typeof(IEnumerable<ICommand>).IsAssignableFrom(property.PropertyType))
                {
                    foreach (ICommand item in (IEnumerable<ICommand>)property.GetValue(command))
                    {
                        await foreach(var choice in item.GetChoices<T>())
                            yield return choice;
                    }
                }
            }
        }
    }
}
