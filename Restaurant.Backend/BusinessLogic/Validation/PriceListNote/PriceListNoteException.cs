using System.Runtime.Serialization;

namespace BusinessLogic.Validation.Customer
{
    [Serializable]
    public class PriceListNoteException : Exception
    {
        private static readonly string DefaultMessage = "PriceListNote exception was thrown.";

        public PriceListNoteException() : base(DefaultMessage)
        {

        }

        public PriceListNoteException(string message) : base(message)
        {

        }

        public PriceListNoteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected PriceListNoteException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
