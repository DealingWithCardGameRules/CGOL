using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardGameWebApp.Shared
{
    public abstract class LinksExtension
    {
        [JsonPropertyName("links")]
        public IDictionary<string, string> Links { get; set; }

        [JsonConstructor]
        public LinksExtension() : base()
        {
        }

        public LinksExtension(string selfLink)
        {
            Links = new Dictionary<string, string>
            {
                { "self", selfLink }
            };
        }
    }
}
