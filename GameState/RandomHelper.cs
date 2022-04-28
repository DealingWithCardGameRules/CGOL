using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal static class RandomHelper
    {
        private static readonly Random random = new Random();

        internal static T RandomOrDefault<T>(this IEnumerable<T> list, T defaultValue = default)
        {
            if (!list.Any())
                return defaultValue;
            return list.ElementAt(random.Next(list.Count()));
        }
    }
}
