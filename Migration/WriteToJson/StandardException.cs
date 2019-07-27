using System;
using System.Runtime.Serialization;

namespace WriteToJson
{
    [Serializable]
    internal class StandardException : Exception
    {
        public StandardException()
        {
        }

        public StandardException(string message) : base(message)
        {
        }

        public StandardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StandardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}