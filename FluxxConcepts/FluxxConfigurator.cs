using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class FluxxConfigurator
    {
        public void AddHandlers(IDispatcher dispatcher, IInterpolator interpolator)
        {
            interpolator.AddConcept(new DrawCardHandler(dispatcher));
        }
    }
}
