using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public static class CommaSeperatedStringHelper
    {
        public static IEnumerable<string> CommaSeperateTrimmed(this string input)
        {
            return input.CommaSeperate().Select(t => t.Trim());
        }

        private static IEnumerable<string> CommaSeperate(this string input)
        {
            return input.Split(',');
        }
    }
}
