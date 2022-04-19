using System;
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
            library = new Dictionary<string, CardDetails>(StringComparer.OrdinalIgnoreCase)
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
                },
                {
                    "Draw 1 Play 1 Rules",
                    new CardDetails {
                        Name = "Draw 1 Play 1 Rules",
                        Illustration="d1p1",
                        Description="During their turn a player draws one card, then plays one card.",
                        Classification = "Rule card"
                    }
                },
                {
                    "Draw 1",
                    new CardDetails {
                        Name = "Draw 1",
                        Illustration="draw",
                        Description="Draw one card.",
                        Classification = "Basic Rule"
                    }
                },
                { 
                    "Draw 2",
                    new CardDetails {
                        Name = "Draw 2",
                        Illustration="draw",
                        Description="Draw two cards.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Play 1",
                    new CardDetails {
                        Name = "Play 1",
                        Illustration="play",
                        Description="Play one card from your hand.",
                        Classification = "Basic Rule"
                    }
                },
                {
                    "Play 2",
                    new CardDetails {
                        Name = "Play 2",
                        Illustration="play",
                        Description="Play two card from your hand.",
                        Classification = "New Rule"
                    }
                }
            };
        }

        public CardDetails GetCard(string template)
        {
            if (library.ContainsKey(template))
                return library[template];
            return new CardDetails
			{
                Name=template,
                Illustration="placeholder"
			};
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
