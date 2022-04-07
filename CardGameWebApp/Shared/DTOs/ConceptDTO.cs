using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class ConceptDTO
    {
        public const string TYPE_COMMAND = "command";
        public const string TYPE_QUERY = "query";
        public const string TYPE_EVENT = "event";

        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ActionParameterDTO> Parameters { get; set; }
        public string Description { get; set; }
    }
}
