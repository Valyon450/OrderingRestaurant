using System.Runtime.Serialization;

namespace BusinessLogic.Validation.Customer
{
    [Serializable]
    public class CustomerException : Exception
    {
        private static readonly string DefaultMessage = "Customer exception was thrown.";

        public CustomerException() : base(DefaultMessage)
        {

        }

        public CustomerException(string message) : base(message)
        {

        }

        public CustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CustomerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
