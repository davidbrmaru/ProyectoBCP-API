using System;
using System.Runtime.Serialization;

namespace ProyectoBCP_API.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base() { }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ForbiddenException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}