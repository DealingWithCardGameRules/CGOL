﻿using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class ZoneDeclaredObserver : IEventObserver<ZoneDeclared>
    {
        private readonly Game game;

        internal ZoneDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(ZoneDeclared @event)
        {
            var zone = new CardZone(@event.Zone);
            
            if (@event.OwnerIndex != null)
            {
                zone.AddTag("zone");
                zone.OwnerIndex = @event.OwnerIndex;
            }
            else
                zone.AddTag("community");

            game.AddCollection(zone);
        }
    }
}
