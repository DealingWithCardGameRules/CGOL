using System.Collections.Generic;

namespace CardGameWebApp.Shared
{
	public class CardDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public string Illustration { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }
}
