using System.Runtime.Serialization;

namespace BusinessLogic.Validation.Order
{
    [Serializable]
    public class OrderException : Exception
    {
        private static readonly string DefaultMessage = "Order exception was thrown.";

        public OrderException() : base(DefaultMessage)
        {

        }

        public OrderException(string message) : base(message)
        {

        }

        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected OrderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
