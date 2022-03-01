using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionRepository
    {
        Dictionary<Guid, Session> sessions;

        public SessionRepository()
        {
            sessions = new Dictionary<Guid, Session>();
        }

        public void AddSession(Session session)
        {
            sessions.Add(session.Instance, session);
        }

        public Session? GetSession(Guid id)
        {
            if (sessions.ContainsKey(id))
                return sessions[id];
            return null;
        }

        public IEnumerable<Session> ListSessions()
        {
            return sessions.Values;
        }

        public void RemoveSession(Guid id)
        {
            if (sessions.ContainsKey(id))
                sessions.Remove(id);
        }
    }
}
