using System;
using System.Runtime.Serialization;

namespace Network.client
{
    [Serializable]
    public class ClientWorkerException : Exception
    {
        private Exception e;

        public ClientWorkerException()
        {
        }

        public ClientWorkerException(Exception e)
        {
            this.e = e;
        }

        public ClientWorkerException(string message) : base(message)
        {
        }

        public ClientWorkerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientWorkerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}