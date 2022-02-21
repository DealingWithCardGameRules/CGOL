using System;
using System.Runtime.Serialization;

namespace dk.itu.game.msc.cgdl
{
    [Serializable]
    public class DuplicateConceptException : Exception
    {
        public DuplicateConceptException()
        {
        }

        public DuplicateConceptException(Type type) : base($"The concept {type} is already loaded. Please unload the concept and try again.")
        {
            Type = type;
        }

        public DuplicateConceptException(string message) : base(message)
        {
        }

        public DuplicateConceptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateConceptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type Type { get; }
    }
}