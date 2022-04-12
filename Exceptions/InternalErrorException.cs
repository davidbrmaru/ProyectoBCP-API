using System;
using System.Runtime.Serialization;

namespace ProyectoBCP_API.Exceptions
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException() : base() { }
        public InternalErrorException(string message) : base(message) { }
        public InternalErrorException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected InternalErrorException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}