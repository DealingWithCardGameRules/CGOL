using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public IServiceProvider Provider { get; }

        public Session(Guid instance, IServiceProvider provider)
        {
            Instance = instance;
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
