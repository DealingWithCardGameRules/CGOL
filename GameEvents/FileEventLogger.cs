using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.IO;

namespace dk.itu.game.msc.cgol.GameEvents
{
    internal class FileEventLogger : IEventLogger
    {
        private readonly string eventStore;
        private readonly IEventSerializer eventSerializer;

        public FileEventLogger(string eventStore, IEventSerializer eventSerializer)
        {
            this.eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            this.eventSerializer = eventSerializer ?? throw new ArgumentNullException(nameof(eventSerializer));
        }

        public IEnumerable<IEvent> EventLog 
        {
            get
            {
                using var eventStoreReader = new StreamReader(eventStore);
                var input = eventStoreReader.ReadLine();
                yield return eventSerializer.Deserialize(input);
            }
        }

        public void AppendLog(IEvent @event)
        {
            using var eventStoreWriter = new StreamWriter(eventStore, append: true);
            eventStoreWriter.WriteLine(eventSerializer.Serialize(@event));
        }
    }
}
