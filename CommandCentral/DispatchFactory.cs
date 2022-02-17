using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public class DispatchFactory
    {
        public IDispatcher Create(IServiceProvider provider)
        {
            return new MessageDispatcher(provider);
        }
    }
}
