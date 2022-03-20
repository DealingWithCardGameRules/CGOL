using CardGameWebApp.Shared.DTOs;

namespace CardGameWebApp.Shared.Responses
{
    public class CardCollectionResponse : LinksExtension
    {
        public CardCollectionDTO CardCollection { get; set; }

        public CardCollectionResponse() { } // Serialize constructor
        public CardCollectionResponse(string selfLink, string actions = null) : base(selfLink)
        {
            if (actions != null)
                Links.Add("actions", actions);
        }
    }
}
