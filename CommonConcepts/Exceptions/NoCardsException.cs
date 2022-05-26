using System;
using System.Runtime.Serialization;

namespace dk.itu.game.msc.cgol.CommonConcepts.Exceptions
{
    [Serializable]
    public class NoCardsException : Exception
    {
        private Guid source;

        public NoCardsException()
        {
        }

        public NoCardsException(Guid source) : base($"No cards left in source: {source}")
        {
            this.source = source;
        }

        public NoCardsException(string message) : base(message)
        {
        }

        public NoCardsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoCardsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}