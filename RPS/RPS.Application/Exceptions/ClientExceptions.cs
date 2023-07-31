using System.Runtime.Serialization;


namespace RPS.Application.Exceptions
{
    public class ClientExceptions : Exception
    {
        public ClientExceptions() { }
        public ClientExceptions(string message) : base(message) { }
        public ClientExceptions(string message, Exception innerException) : base(message, innerException) { }
        public ClientExceptions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
