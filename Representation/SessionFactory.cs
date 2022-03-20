using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public Session Create(Guid id)
        {
            var service = new CGDLServiceFactory().CreateBasicGame();
            return new Session(id, service);
        }
    }
}
