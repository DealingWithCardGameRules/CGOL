using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public CGOLService Service { get; }
        public IInterpreter Interpreter { get; }
        public PlayerRepository PlayerRepository { get; }
        public IEvent[] Saved { get; private set; }

        public Session(Guid instance, CGOLService service, IInterpreter interpreter, PlayerRepository playerRepository)
        {
            Instance = instance;
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Interpreter = interpreter ?? throw new ArgumentNullException(nameof(interpreter));
            PlayerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }

        public void Save()
        {
            Saved = Service.SessionEvents.ToArray();
        }
    }
}
