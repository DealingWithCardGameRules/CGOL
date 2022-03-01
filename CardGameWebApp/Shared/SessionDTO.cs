using System;

namespace CardGameWebApp.Shared
{
    public class SessionDTO 
    {
        public Guid SessionId { get; }

        public SessionDTO() {  }

        public SessionDTO(Guid sessionId)
        {
            SessionId = sessionId;
        }
    }
}
