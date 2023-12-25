using BusinessLogic.DTO;

namespace BusinessLogic.Validation.Customer
{
    public static class CustomerValidation
    {
        public static void CheckCustomer(CustomerDTO customerDTO)
        {
            if (string.IsNullOrEmpty(customerDTO.SurName))
            {
                throw new CustomerException($"{nameof(CustomerDTO.SurName)} is empty.");
            }

            if (string.IsNullOrEmpty(customerDTO.Name))
            {
                throw new CustomerException($"{nameof(CustomerDTO.Name)} is empty.");
            }
        }

    }
}
