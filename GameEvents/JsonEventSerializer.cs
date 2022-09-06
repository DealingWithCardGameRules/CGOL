using dk.itu.game.msc.cgol.Distribution;
using Newtonsoft.Json;
using System;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class JsonEventSerializer : IEventSerializer
    {
        private readonly IInterpreter interpreter;

        public JsonEventSerializer(IInterpreter interpreter)
        {
            this.interpreter = interpreter ?? throw new ArgumentNullException(nameof(interpreter));
        }

        public IEvent Deserialize(string input)
        {
            (var name, var json) = input.Split(':', 2);

            Type type = interpreter.Resolve<IEvent>(name) ?? throw new Exception($"Could not find event: {name}");
            return (IEvent)JsonConvert.DeserializeObject(json, type) ?? throw new Exception($"Could not deserialize json for: {name}");
        }

        public string Serialize(IEvent @event)
        {
            var jsonEvent = JsonConvert.SerializeObject(@event);
            return $"\"{@event.GetType().Name}\":{jsonEvent}";
        }
    }
}
