using CardGameWebApp.Shared.DTOs;

namespace CardGameWebApp.Shared.Responses
{
    public class ActionResponse : LinksExtension
    {
        public ActionDTO Action;
        public ActionResponse() { } // Serialize constructor
        public ActionResponse(ActionDTO action, string selfLink) : base(selfLink)
        {
            Action = action ?? throw new System.ArgumentNullException(nameof(action));
        }
    }
}
