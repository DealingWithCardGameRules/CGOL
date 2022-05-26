using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Representation
{
    public interface ISessionService
    {
        void Create(Guid id, IUserEnquirerFactory userEnquirer);
        Session? GetSession(Guid id);
        IEnumerable<Session> ListSessions();
    }
}