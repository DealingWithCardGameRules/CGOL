using System.Collections.Generic;

namespace CardGameWebApp.Shared
{
    public class SessionList : LinksExtension
    {
        public IEnumerable<SessionDTO> Sessions { get; }

        public SessionList(IEnumerable<SessionDTO> sessions, string selfLink) : base(selfLink)
        {
            Sessions = sessions;
        }
    }
}
