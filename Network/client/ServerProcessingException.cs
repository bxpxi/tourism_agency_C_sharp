﻿using System;
using System.Runtime.Serialization;

namespace Network.client
{
    [Serializable]
    public class ServerProcessingException : Exception
    {
        private Exception e;

        public ServerProcessingException()
        {
        }

        public ServerProcessingException(Exception e)
        {
            this.e = e;
        }

        public ServerProcessingException(string message) : base(message)
        {
        }

        public ServerProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServerProcessingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}