using System.Collections.Generic;

namespace CardGameWebApp.Shared.DTOs
{
    public class ActionDTO
    {
        public IEnumerable<ActionParameterDTO> Parameters { get; set; }
    }
}
