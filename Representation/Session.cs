using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public CGDLService Service { get; }
        public IInterpolator Interpolator { get; }

        public Session(Guid instance, CGDLService service, IInterpolator interpolator)
        {
            Instance = instance;
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
        }
    }
}
