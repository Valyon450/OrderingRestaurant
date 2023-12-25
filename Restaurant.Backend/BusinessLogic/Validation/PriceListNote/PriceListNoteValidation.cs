using BusinessLogic.DTO;

namespace BusinessLogic.Validation.Customer
{
    public static class PriceListNoteValidation
    {
        public static void CheckPriceListNote(PriceListNoteDTO priceListNoteDTO)
        {
            if (priceListNoteDTO.DishId == Guid.Empty)
            {
                throw new PriceListNoteException($"{nameof(PriceListNoteDTO.DishId)} should be valid.");
            }

            if (string.IsNullOrEmpty(priceListNoteDTO.PortionSize))
            {
                throw new PriceListNoteException($"{nameof(PriceListNoteDTO.PortionSize)} is empty.");
            }

            if (priceListNoteDTO.Price <= 0)
            {
                throw new PriceListNoteException($"{nameof(priceListNoteDTO.Price)} should be greater than zero.");
            }
        }

    }
}
