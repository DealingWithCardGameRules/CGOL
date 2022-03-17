using System;
using System.Runtime.Serialization;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    [Serializable]
    public class GDLParserException : Exception
    {
        public GDLParserException()
        {
        }

        public GDLParserException(string message) : base(message)
        {
        }

        public GDLParserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GDLParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}