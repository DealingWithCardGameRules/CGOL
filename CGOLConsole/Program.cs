using CGOLConsole.Commands;

namespace CGOLConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Welcome to the Card Game Operational Language.");
            var service = new ConsoleCGOLFactory().Create();
            service.LoadConcepts(new ConsoleSetup());

            if (args.Length > 0)
                service.Dispatch(new LoadCard(args[0]));

            Console.WriteLine("Ready to recieve commands (use > for user actions):");
            string? input;
            while ((input = Read("")) != null)
            {
                try
                {
                    if (input.StartsWith(">"))
                        Parse(input.Substring(1));
                    else
                        service.Parse(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        static void Parse(string input)
        {
            Console.WriteLine($"Right! {input}");
        }

        static string? Read(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}