using System.Collections.Generic;

namespace CardGameWebApp.Shared
{
	public class CardDescriptionDTO
    {
        public string Template { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }
}
