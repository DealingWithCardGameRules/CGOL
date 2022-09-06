using CGOLConsole.Commands;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser.Messages;

namespace CGOLConsole.Handlers
{
    public class LoadCardHandler : ICommandHandler<LoadCard>
    {
        private const string dataFileExtension = ".cgd";
        private readonly IDispatcher dispatcher;

        public LoadCardHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(LoadCard command, IEventDispatcher eventDispatcher)
        {
            try
            {
                using var stream = File.OpenRead($"{command.File}{dataFileExtension}");
                var data = new StreamReader(stream).ReadToEnd();
                dispatcher.Dispatch(new LoadCGOL(data));
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Unable to find {command.File}. Remember to add folders e.g. \"folder/{command.File}\" or \"folder/subfolder/{command.File}\"");
            }
        }
    }
}
