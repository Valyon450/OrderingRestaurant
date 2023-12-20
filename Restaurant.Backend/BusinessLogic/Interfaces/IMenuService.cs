using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IMenuService
    {
        IEnumerable<PriceListNoteDTO> GetAllPriceListNotes();

        Task<PriceListNoteDTO> GetPriceListNoteByIdAsync(Guid id);

        Task AddPriceListNoteAsync(PriceListNoteDTO model);

        Task DeletePriceListNoteByIdAsync(Guid modelId);
    }
}
