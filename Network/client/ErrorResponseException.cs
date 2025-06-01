using System;
using System.Runtime.Serialization;

namespace Network.client
{
    [Serializable]
    public class ErrorResponseException : Exception
    {
        public ErrorResponseException()
        {
        }

        public ErrorResponseException(string message) : base(message)
        {
        }

        public ErrorResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}