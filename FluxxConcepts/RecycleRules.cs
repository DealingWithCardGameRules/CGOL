using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class RecycleRules
    {
        private Dictionary<string, string> recycles;

        public RecycleRules()
        {
            recycles = new Dictionary<string, string>();
        }

        internal void SetRule(string from, string to)
        {
            recycles[to] = from;
        }

        internal void ApplyRule(string collection, Action<string, string> ruleActions)
        {
            if (recycles.ContainsKey(collection))
                ruleActions.Invoke(recycles[collection], collection);
        }

        internal bool HasRule(string collection)
        {
            return recycles.ContainsKey(collection);
        }
    }
}
