using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal static class CommaSeperatedStringHelper
    {
        public static IEnumerable<string> GetTagsTrimmed(this string input)
        {
            return input.GetTags().Select(t => t.Trim());
        }

        private static IEnumerable<string> GetTags(this string input)
        {
            return input.Split(',');
        }

    }
}
