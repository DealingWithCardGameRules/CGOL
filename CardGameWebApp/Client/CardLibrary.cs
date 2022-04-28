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
                        Illustration="d1p1",
                        Description="During their turn a player draws one card, then plays one card.",
                        Classification = "Rule card"
                    }
                },

                // Fluxx
                // Rules
                {
                    "Draw 1",
                    new CardDetails {
                        Illustration="draw",
                        Description="Draw one card.",
                        Classification = "Basic Rule"
                    }
                },
                { 
                    "Draw 2",
                    new CardDetails {
                        Illustration="draw",
                        Description="Draw two cards.",
                        Classification = "New Rule"
                    }
                },
                                {
                    "Draw 3",
                    new CardDetails {
                        Illustration="draw",
                        Description="Draw three cards.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Draw 4",
                    new CardDetails {
                        Illustration="draw",
                        Description="Draw four cards.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Draw 5",
                    new CardDetails {
                        Illustration="draw",
                        Description="Draw five cards.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Play 1",
                    new CardDetails {
                        Illustration="play",
                        Description="Play one card from your hand.",
                        Classification = "Basic Rule"
                    }
                },
                {
                    "Play 2",
                    new CardDetails {
                        Illustration="play",
                        Description="Play two card from your hand.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Play 3",
                    new CardDetails {
                        Illustration="play",
                        Description="Play three card from your hand.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Play 4",
                    new CardDetails {
                        Illustration="play",
                        Description="Play four card from your hand.",
                        Classification = "New Rule"
                    }
                },
                {
                    "Play 5",
                    new CardDetails {
                        Illustration="play",
                        Description="Play five card from your hand.",
                        Classification = "New Rule"
                    }
                },
                {
                    "No-Hand Bonus",
                    new CardDetails {
                        Description="Start-of-Turn Event. If empty handed, draw 2 cards before observing the current draw rule.",
                        Classification = "New Rule"
                    }
                },
                // Actions
                {
                    "Draw 2 and Use 'em",
                    new CardDetails {
                        Description="Set your hand aside. Draw 2 cards, play them in any order you choose, then pick up your hand and continue with your turn. This card and all cards played because of it, are counter as a single play.",
                        Classification = "Action"
                    }
                },
                {
                    "Jackpot!",
                    new CardDetails {
                        Description="Draw 3 extra cards!",
                        Classification = "Action"
                    }
                },
                {
                    "Rules Reset",
                    new CardDetails {
                        Description="Reset to the Basic Rules. Discard all New Rule cards, and leave only the Basic Rules in play. Do not discard the current Goal.",
                        Classification = "Action"
                    }
                },
                // Goals
                {
                    "Squishy Chocolate",
                    new CardDetails {
                        Description="Chocolate + The Sun.",
                        Classification = "Goal"
                    }
                },
                // Keepers
                {
                    "The Brain",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Bread",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Chocolate",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Cookies",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Party",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Peace",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Rocket",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Sleep",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Sun",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Television",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Toaster",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Time",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Cosmos",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Dreams",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Eye",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Love",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Milk",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "Money",
                    new CardDetails {
                        Classification = "Keeper"
                    }
                },
                {
                    "The Moon",
                    new CardDetails {
                        Classification = "Keeper"
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
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public string? Illustration { get; set; }
    }
}
