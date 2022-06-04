using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Representation.Handlers;
using dk.itu.game.msc.cgol.Representation.Observers;
using System;

namespace dk.itu.game.msc.cgol.Representation
{
    public class SessionFactory
    {

        public Session ResetSession(Session session, IUserEnquirerFactory userEnquirerFactory)
        {
            var factory = new CGOLServiceFactory();
            var service = factory.CreateBasic();
            var interpreter = factory.GetInterpreter();
            var userEnquirer = userEnquirerFactory.Create(session.PlayerRepository);
            AddHandlers(interpreter, userEnquirer);
            return new Session(session.Instance, service, interpreter, session.PlayerRepository);
        }

        public Session CreateSession(Guid id, IUserEnquirerFactory userEnquirerFactory)
        {
            var factory = new CGOLServiceFactory();
            var service = factory.CreateBasic();
            var interpreter = factory.GetInterpreter();
            var playerRepository = new PlayerRepository(id.ToString());
            var userEnquirer = userEnquirerFactory.Create(playerRepository);
            AddHandlers(interpreter, userEnquirer);
            return new Session(id, service, interpreter, playerRepository);
        }

        private void AddHandlers(IInterpreter interpreter, IUserEnquirer userEnquirer)
        {
            // Setup handlers
            interpreter.AddConcept(new PickACardHandler(userEnquirer));
            interpreter.AddConcept(new PlayerAgreeHandler(userEnquirer));

            // Setup observers
            interpreter.AddConcept(new PlayerWonObserver(userEnquirer));
        }
    }
}
