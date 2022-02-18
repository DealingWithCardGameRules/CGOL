using System.IO;

namespace dk.itu.game.msc.cgdl.GameEvents
{
    public class EventLoggerFactory
    {
        public IEventLogger NewLog(string path, string fileName)
        {
            var eventStore = GetEventStore(path, fileName);

            if (File.Exists(eventStore))
                File.Delete(eventStore);

            return new EventLogger(eventStore);
        }

        public IEventLogger ContinueLog(string path, string fileName)
        {
            var eventStore = GetEventStore(path, fileName);
            return new EventLogger(eventStore);
        }

        private string GetEventStore(string path, string fileName)
        {
            var eventStorePath = Path.GetFullPath(path);
            Directory.CreateDirectory(eventStorePath);

            return eventStorePath + fileName;
        }
    }
}
