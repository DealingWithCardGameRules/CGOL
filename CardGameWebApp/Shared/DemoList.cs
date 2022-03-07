using System.Text.Json.Serialization;

namespace CardGameWebApp.Shared
{
	public class DemoList : LinksExtension
    {
        [JsonConstructor]
        public DemoList() : base()
        {
        }

        public DemoList(string selfLink) : base(selfLink)
        {

        }
    }
}
