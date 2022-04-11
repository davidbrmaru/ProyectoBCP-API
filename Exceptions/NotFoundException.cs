using System;
using System.Runtime.Serialization;

namespace ProyectoBCP_API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected NotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}