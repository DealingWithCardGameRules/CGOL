using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    internal class EventType : IToken
    {
        public SupportedEvent Value { get; private set; }

        public string RawValue { get; private set; }

        public string Type => "literal";

        public void Parse(string value)
        {
            RawValue = value;
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
        //Drawn,
        Active
    }
}
