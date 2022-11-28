using CGOLConsole.Commands;
using dk.itu.game.msc.cgol;

namespace CGOLConsole
{
    internal class Program
    {
        private static CGOLService? service;
        private static GameStats stats;

        static Task Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Welcome to the Card Game Operational Language.");
            service = new ConsoleCGOLFactory().Create();
            var setup = new ConsoleSetup();
            service.LoadConcepts(setup);
            stats = setup.Stats;

            if (args.Length > 0)
                service.Dispatch(new LoadCard(args[0]));

            Console.WriteLine("Ready to recieve commands (use > for user actions):");
            StartInputLoop("", (input) =>
            {
                try
                {
                    if (input.StartsWith(">"))
                        Parse(input[1..]);
                    else
                        service.Parse(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
            return Task.CompletedTask;
        }

        static async Task Parse(string input)
        {
            if (input.StartsWith("rand", StringComparison.OrdinalIgnoreCase))
            {
                // Play randomly
                Console.WriteLine("Random agent started.");
                try
                {
                    while (!stats.gameOver)
                    {
                        await stats.AddStats();
                        Console.Write("Random agent is choosing action... ");
                        var ai = new AIAgentFactory().CreateRandom();
                        var action = await ai.Choose(service.SessionEvents.ToArray());
                        Console.WriteLine($"[{action.GetType().Name}]");
                        await service.Dispatch(action);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception thrown");
                    Console.WriteLine(ex);
                }

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Quick stats!");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Winning player: {stats.playerWon}");
                Console.WriteLine($"Average player: {stats.AvgPlayer:F}");
                Console.WriteLine($"Average cards: {stats.AvgCards:F}");
                Console.WriteLine($"Average decks: {stats.AvgDecks:F}");
                Console.WriteLine($"Average actions: {stats.AvgActions:F}");
                Console.WriteLine($"Average options: {stats.AvgOptions:F}");

            }
        }

        static void StartInputLoop(string prompt, Action<string> handler)
        {
            string? line;
            while (true)
            {
                Console.Write(prompt);
                line = Console.ReadLine();
                if (line == null)
                    return;

                handler(line);
            }
        }
    }
}