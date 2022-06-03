using System.IO;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class EventLogFactory
    {
        public IEventSerializer Serializer { get; set; } = new JsonEventSerializer();

        public string AbsoluteFile(string path, string file)
        {
            return $"{Path.GetFullPath(path)}{file}";
        }

        public void CreatePath(string path)
        {
            Directory.CreateDirectory(Path.GetFullPath(path));
        }

        public void ResetFile(string absoluteFile)
        {
            if (File.Exists(absoluteFile))
                File.Delete(absoluteFile);
        }

        public IEventLogger CreateFileLogger(string absoluteFile)
        {
            if (!File.Exists(absoluteFile))
                throw new FileNotFoundException($"Use the {nameof(AbsoluteFile)} method to get absolute file path and use {nameof(CreatePath)} to create dictionary.");
            return Wrap(new FileEventLogger(absoluteFile, Serializer));
        }

        public IEventLogger CreateMemoryLogger()
        {
            return Wrap(new MemoryEventLogger());
        }

        private IEventLogger Wrap(IEventLogger eventLogger)
        {
            return new AppendOnlyDecorator(eventLogger);
        }
    }
}
