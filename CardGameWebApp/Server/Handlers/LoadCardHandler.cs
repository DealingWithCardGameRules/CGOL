using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser.Messages;
using dk.itu.game.msc.cgol.Representation.Command;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Handlers
{
    public class LoadCardHandler : ICommandHandler<LoadCard>
    {
        private readonly IDispatcher dispatcher;
        private readonly StorageService storage;
        private readonly WebContext context;

        public LoadCardHandler(IDispatcher dispatcher, StorageService storage, WebContext context)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Handle(LoadCard command, IEventDispatcher eventDispatcher)
        {
            try
            {
                var cgd = storage.GetFile($"{context.User}/{command.File}");
                dispatcher.Dispatch(new LoadCGOL(cgd));
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Unable to find {command.File}. Remember to add folders e.g. \"folder/{command.File}\" or \"folder/subfolder/{command.File}\"");
            }
        }
    }
}
