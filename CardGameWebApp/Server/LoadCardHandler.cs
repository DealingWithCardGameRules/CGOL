using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Messages;
using dk.itu.game.msc.cgdl.Representation.Command;
using System;
using System.IO;

namespace CardGameWebApp.Server
{
    public class LoadCardHandler : ICommandHandler<LoadCard>
    {
        private readonly CGDLService service;
        private readonly StorageService storage;
        private readonly WebContext context;

        public LoadCardHandler(CGDLService service, StorageService storage, WebContext context)
        {
            this.service = service ?? throw new System.ArgumentNullException(nameof(service));
            this.storage = storage ?? throw new System.ArgumentNullException(nameof(storage));
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public void Handle(LoadCard command, IEventDispatcher eventDispatcher)
        {
            try
            {
                var cgd = storage.GetFile($"{context.User}/{command.File}");
                service.Dispatch(new LoadCGDL(cgd));
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Unable to find {command.File}. Remember to add folders e.g. \"folder/{command.File}\" or \"folder/subfolder/{command.File}\"");
            }
        }
    }
}
