using dk.itu.game.msc.cgdl.Common.Commands;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Linq;
using System.Reflection;

namespace dk.itu.game.msc.cgdl.Handlers
{
    public class LoadBehaviorHandler : ICommandHandler<LoadBehavior>
    {
        private readonly IPluginContext context;

        public LoadBehaviorHandler(IPluginContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Handle(LoadBehavior command, IEventDispatcher eventDispatcher)
        {
            var assembly = Assembly.Load(command.AssemblyName);
            Type type;
            var types = assembly.GetExportedTypes();
            if (command.SetupClass != null)
            {
                var name = types.Single(t => t.Name.Equals(command.SetupClass)).FullName;
                type = assembly.GetType(name);
            }
            else
                type = types.FirstOrDefault(t => t.GetInterface(typeof(IPluginSetup).Name) != null);

            if (type == null || type.GetInterface(typeof(IPluginSetup).Name) == null)
                throw new Exception("Unable to find setup class. Please note that the setup class must inherit from IPluginSetup.");

            IPluginSetup setup = (IPluginSetup)Activator.CreateInstance(type);
            setup.Setup(context);
        }
    }
}
