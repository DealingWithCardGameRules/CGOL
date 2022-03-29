using dk.itu.game.msc.cgdl.CommandCentral;

namespace CardGameGL.AcceptTest.Support
{
    internal class DispatchLogger : IDispatcher
    {
        private readonly IDispatcher decoratee;

        public DispatchLogger(IDispatcher decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public void Dispatch(ICommand command)
        {
            Console.WriteLine($"Dispatching command: {command.GetType().Name}");
            decoratee.Dispatch(command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Console.WriteLine($"Dispatching query: {query.GetType().Name}");
            var result = decoratee.Dispatch<T>(query);
            Console.WriteLine($"Result for {query.GetType().Name}: {result}");
            return result;
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            Console.WriteLine($"Dispatching query: {query.GetType().Name}");
            var result = await decoratee.DispatchAsync<T>(query);
            Console.WriteLine($"Result for {query.GetType().Name}: {result}");
            return result;
        }
    }
}
