using System.Runtime.Serialization;

namespace BusinessLogic.Validation.Dish
{
    [Serializable]
    public class DishException : Exception
    {
        private static readonly string DefaultMessage = "Dish exception was thrown.";

        public DishException() : base(DefaultMessage)
        {

        }

        public DishException(string message) : base(message)
        {

        }

        public DishException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DishException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
