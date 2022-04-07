namespace CardGameWebApp.Shared.DTOs
{
    public class ActionParameterDTO
    {
        public const string TYPE_NUMBER = "number";
        public const string TYPE_STRING = "string";

        public string Name { get; set; }
        public string Target { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public string Description { get; set; }
    }
}