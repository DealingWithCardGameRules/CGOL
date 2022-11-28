using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agents
{
    internal static class CollectionRandomnessHelper
    {
        private static readonly Random random = new Random();

        public static T Random<T>(this IEnumerable<T> collection)
        {
            return collection.ElementAt(random.Next(collection.Count()));
        }

        public static async Task<T> Random<T>(this IAsyncEnumerable<T> collection)
        {
            return await collection.ElementAtAsync(random.Next(await collection.CountAsync()));
        }
    }
}
