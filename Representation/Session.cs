using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public CGDLService Service { get; }
        public IInterpolator Interpolator { get; }
        public PlayerRepository PlayerRepository { get; }

        public Session(Guid instance, CGDLService service, IInterpolator interpolator, PlayerRepository playerRepository)
        {
            Instance = instance;
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
            PlayerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }
    }
}
