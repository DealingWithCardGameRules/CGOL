using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class CardCollectionDTO
    {
        public IEnumerable<CardRefDTO> VisibleCards { get; set; }
        public int CardCount { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }
}
