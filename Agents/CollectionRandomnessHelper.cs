using System;
using System.Collections.Generic;
using System.Linq;

namespace Agents
{
    internal static class CollectionRandomnessHelper
    {
        private static readonly Random random = new Random();

        public static T Random<T>(this IEnumerable<T> collection)
        {
            return collection.ElementAt(random.Next(collection.Count()));
        }
    }
}
