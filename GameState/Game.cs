using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class Game
    {
        Dictionary<Guid, CardStack> stacks;

        public Game()
        {
            stacks = new Dictionary<Guid, CardStack>();
        }

        internal void AddStack(CardStack stack)
        {
            stacks.Add(stack.Instance, stack);
        }

        internal void AddCard(Guid stack, ICard card)
        {
            stacks[stack].AddCard(card);
        }
    }
}
