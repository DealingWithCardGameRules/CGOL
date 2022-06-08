namespace CGOLConsole
{
    internal class ConsoleWriter
    {
        public void Write(string message, object obj)
        {
            Console.WriteLine($"{DateTime.Now}: {message}", obj);
        }
    }
}
