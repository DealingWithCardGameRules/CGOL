﻿using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole
{
    internal class ConsoleEventDispatchDecorator : IEventDispatcher
    {
        private readonly IEventDispatcher dispatcher;
        private readonly ConsoleWriter consoleWriter;

        public ConsoleEventDispatchDecorator(IEventDispatcher dispatcher, ConsoleWriter consoleWriter)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            this.consoleWriter = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter));
        }

        public async Task Dispatch(IEvent @event)
        {
            consoleWriter.Write(@event);
            await dispatcher.Dispatch(@event);
        }
    }
}
