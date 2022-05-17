using System;

namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    internal class EventType : Token
    {
        public SupportedEvent Value { get; private set; }

        public override string Type => "literal";

        public EventType(string value) : base(value)
        {
            Value = (SupportedEvent)Enum.Parse(typeof(SupportedEvent), value, true);
        }

        public override string ToString()
        {
            return "Event type";
        }
    }

    internal enum SupportedEvent
    {
        Played,
        Drawn,
        Active
    }
}
