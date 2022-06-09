using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole
{
    internal class ConsoleWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        public void Write(IEvent @event)
        {
            if (@event.GetType().ToString() != @event.ToString())
                Console.WriteLine($"{DateTime.Now} [Event][{@event.GetType().Name}]: {@event}");
            else
                Console.WriteLine($"{DateTime.Now} [Event][{@event.GetType().Name}]");
        }
    }
}
