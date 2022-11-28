using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Common
{
    public class MaybeQuery<ValueType>
    {
        private readonly IEnumerable<ValueType> values;
        private readonly IQuery<ValueType>? query;

        public MaybeQuery(ValueType value) => values = new[] { value };

        public MaybeQuery(IQuery<ValueType> query)
        {
            this.query = query ?? throw new System.ArgumentNullException(nameof(query));
            values = new ValueType[0];
        }

        public bool HasValue => values.Any();

        public async Task<ValueType> Value(IQueryDispatcher dispatcher)
        {
            if (!HasValue)
                return await dispatcher.Dispatch(query);
            return values.Single();
        }
    }
}
