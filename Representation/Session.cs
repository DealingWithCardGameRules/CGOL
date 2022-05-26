using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public CGOLService Service { get; }
        public IInterpreter Interpolator { get; }
        public PlayerRepository PlayerRepository { get; }

        public Session(Guid instance, CGOLService service, IInterpreter interpolator, PlayerRepository playerRepository)
        {
            Instance = instance;
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
            PlayerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }
    }
}
