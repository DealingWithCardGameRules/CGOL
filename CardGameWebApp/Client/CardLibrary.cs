using System.Collections.Generic;

namespace CardGameWebApp.Client
{
    public class CardLibrary
    {
        private static CardLibrary instance;
        public static CardLibrary Instance {
            get {
                if (instance == null)
                    instance = new CardLibrary();
                return instance;
            }
        }

        private Dictionary<string, CardDetails> library;
        private CardLibrary()
        {
            library = new Dictionary<string, CardDetails>
            {
                {
                    "pass",
                    new CardDetails
                    {
                        Name = "Pass",
                        Illustration = "Pass",
                        Description = "Does nothing.",
                        Classification = "Useless"
                    }
                }
            };
        }

        public CardDetails GetCard(string template)
        {
            if (library.ContainsKey(template.ToLower()))
                return library[template.ToLower()];
            return null;
        }
    }

    public class CardDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public string Illustration { get; set; }
    }
}
