﻿using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class TagsAddedToCollectionObserver : IEventObserver<TagsAddedToCollection>
    {
        private readonly Game game;

        internal TagsAddedToCollectionObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(TagsAddedToCollection @event)
        {
            foreach (var tag in @event.Tags)
                game.AddTag(@event.Collection, tag);
        }
    }
}
