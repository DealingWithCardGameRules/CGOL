using System;
using System.Runtime.Serialization;

namespace dk.itu.game.msc.cgdl
{
    [Serializable]
    internal class UnknownConceptException : Exception
    {
        public UnknownConceptException(Type serviceType) : base($"The concept {serviceType} isn't loaded. Please load all needed concepts before applying them in game.")
        {
            ServiceType = serviceType;
        }

        public UnknownConceptException(string message) : base(message)
        {
        }

        public UnknownConceptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownConceptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type ServiceType { get; }
    }
}