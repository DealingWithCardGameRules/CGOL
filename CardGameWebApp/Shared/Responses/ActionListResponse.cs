using System.Collections.Generic;

namespace CardGameWebApp.Shared.Responses
{
    public class ActionListResponse : LinksExtension
    {
        public IDictionary<string, string> Actions { get; set; }

        public ActionListResponse()
        {

        }

        public ActionListResponse(string selfLink) : base(selfLink)
        {

        }
    }
}
