using dk.itu.game.msc.cgdl.Representation.Handlers;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public Session CreateSession(Guid id, IUserEnquirerFactory userEnquirerFactory)
        {
            var factory = new CGDLServiceFactory();
            var service = factory.CreateBasicGame();
            var playerRepository = new PlayerRepository();
            var interpolator = factory.GetInterpolator();
            var userEnquirer = userEnquirerFactory.Create(playerRepository);

            // Setup handlers
            interpolator.AddConcept(new PickACardHandler(userEnquirer));

            return new Session(id, service, interpolator, playerRepository);
        }

    }
}
