namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IInterpolator
    {
        public bool Supports<T>(T type);
        public bool Supports<T>();
        public void AddConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        public void AddConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        public void AddConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
        public void RemoveConcept<T>(ICommandHandler<T> commandHandler) where T : ICommand;
        public void RemoveConcept<T, TResult>(IQueryHandler<T, TResult> queryHandler) where T : IQuery<TResult>;
        public void RemoveConcept<T>(IEventObserver<T> eventObserver) where T : IEvent;
    }
}
