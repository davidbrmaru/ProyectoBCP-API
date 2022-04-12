using System;
using System.Runtime.Serialization;

namespace ProyectoBCP_API.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected BadRequestException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}