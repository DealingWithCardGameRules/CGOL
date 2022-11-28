using dk.itu.game.msc.cgol.Distribution;

namespace CardGameGL.AcceptTest.Support
{
    internal class DispatchLogger : IDispatcher
    {
        private readonly IDispatcher decoratee;

        public DispatchLogger(IDispatcher decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task Dispatch(ICommand command)
        {
            Console.WriteLine($"Dispatching command: {command.GetType().Name}");
            await decoratee.Dispatch(command);
        }

        public async Task<T> Dispatch<T>(IQuery<T> query)
        {
            Console.WriteLine($"Dispatching query: {query.GetType().Name}");
            var result = await decoratee.Dispatch<T>(query);
            Console.WriteLine($"Result for {query.GetType().Name}: {result}");
            return result;
        }
    }
}
