using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class Session
    {
        public Guid Instance { get; }
        public CGDLService Service { get; }

        public Session(Guid instance, CGDLService service)
        {
            Instance = instance;
            Service = service;
        }
    }
}
