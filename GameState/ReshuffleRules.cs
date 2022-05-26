using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class ReshuffleRules
    {
        private Dictionary<string, string> reshuffles;

        public ReshuffleRules()
        {
            reshuffles = new Dictionary<string, string>();
        }

        internal void SetRule(string from, string to)
        {
            reshuffles[to] = from;
        }

        internal void ApplyRule(string collection, Action<string, string> ruleActions)
        {
            if (reshuffles.ContainsKey(collection))
                ruleActions.Invoke(reshuffles[collection], collection);
        }

        internal string? GetRule(string destination)
        {
            if (reshuffles.ContainsKey((string)destination))
                return reshuffles[destination];
            return null;
        }

        internal bool HasRule(string collection)
        {
            return reshuffles.ContainsKey(collection);
        }
    }
}
