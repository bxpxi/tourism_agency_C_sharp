﻿using System;

namespace Network.objectprotocol
{
    [Serializable]
    public class ErrorResponse : IResponse
    {
        public string Message { get; set; }
        public ErrorResponse(string message) => Message = message;
        public override string ToString() => $"ErrorResponse {{ Message = {Message} }}";
    }
}