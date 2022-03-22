namespace CardGameWebApp.Shared.Responses
{
    public class SessionResponse : LinksExtension
    {
        public SessionDTO Session { get; set; }

        public SessionResponse() { }

        public SessionResponse(string selfLink) : base(selfLink)
        {
        }
    }
}
