using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardGameWebApp.Shared
{
    public abstract class LinksExtension
    {
        [JsonPropertyName("_links")]
        public IDictionary<string, string> Links { get; }

        public LinksExtension(string selfLink)
        {
            Links = new Dictionary<string, string>
            {
                { "self", selfLink }
            };
        }
    }
}
