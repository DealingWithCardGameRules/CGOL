using dk.itu.game.msc.cgol.Distribution;
using Newtonsoft.Json;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class JsonEventSerializer : IEventSerializer
    {
        public string Serialize(IEvent @event)
        {
            var jsonEvent = JsonConvert.SerializeObject(@event);
            return $"\"{@event.GetType().Name}\":{jsonEvent}";
        }
    }
}
