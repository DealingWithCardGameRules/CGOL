using dk.itu.game.msc.cgdl.Representation.Handlers;
using dk.itu.game.msc.cgdl.Representation.Observers;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public Session CreateSession(Guid id, IUserEnquirerFactory userEnquirerFactory)
        {
            var factory = new CGDLServiceFactory();
            var service = factory.CreateBasicGame();
            var playerRepository = new PlayerRepository(id.ToString());
            var interpolator = factory.GetInterpolator();
            var userEnquirer = userEnquirerFactory.Create(playerRepository);

            // Setup handlers
            interpolator.AddConcept(new PickACardHandler(userEnquirer));
            interpolator.AddConcept(new PlayerAgreeHandler(userEnquirer));

            // Setup observers
            interpolator.AddConcept(new PlayerWonObserver(userEnquirer));
            
            return new Session(id, service, interpolator, playerRepository);
        }

    }
}
