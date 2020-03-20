﻿using System;
using System.Collections.Generic;
using Topos.Consumer;

namespace Topos.Serialization
{
    public class TransportMessage
    {
        public Dictionary<string, string> Headers { get; }
        public byte[] Body { get; }

        public TransportMessage(Dictionary<string, string> headers, byte[] body)
        {
            Headers = headers ?? throw new ArgumentNullException(nameof(headers));
            Body = body;
        }
    }

    public class ReceivedTransportMessage : TransportMessage
    {
        public Position Position { get; }

        public ReceivedTransportMessage(Position position, Dictionary<string, string> headers, byte[] body) : base(headers, body)
        {
            Position = position;
        }
    }
}
