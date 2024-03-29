﻿using dk.itu.game.msc.cgol.Common.Commands;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Handlers
{
    public class LoadBehaviorHandler : ICommandHandler<LoadBehavior>
    {
        private readonly IPluginContext context;

        public LoadBehaviorHandler(IPluginContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Handle(LoadBehavior command, IEventDispatcher eventDispatcher)
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
