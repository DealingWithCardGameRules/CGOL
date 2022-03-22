using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public Session Create(Guid id)
        {
            var factory = new CGDLServiceFactory();
            var service = factory.CreateBasicGame();
            return new Session(id, service, factory.GetInterpolator());
        }
    }
}
