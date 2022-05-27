using dk.itu.game.msc.cgol.Representation.Handlers;
using dk.itu.game.msc.cgol.Representation.Observers;
using System;

namespace dk.itu.game.msc.cgol.Representation
{
    public class SessionFactory
    {
        public Session CreateSession(Guid id, IUserEnquirerFactory userEnquirerFactory)
        {
            var factory = new CGOLServiceFactory();
            var service = factory.CreateBasicGame();
            var playerRepository = new PlayerRepository(id.ToString());
            var interpolator = factory.GetInterpreter();
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
