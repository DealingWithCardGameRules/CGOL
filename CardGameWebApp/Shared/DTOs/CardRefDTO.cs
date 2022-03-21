using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class CardRefDTO
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }
}
