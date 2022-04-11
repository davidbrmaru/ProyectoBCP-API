using System;
using System.Runtime.Serialization;

namespace ProyectoBCP_API.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base() { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected UnauthorizedException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}