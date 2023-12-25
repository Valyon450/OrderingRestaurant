namespace BusinessLogic.Interfaces
{
    public interface ICrud<DTO> where DTO : class
    {
        IEnumerable<DTO> GetAll();

        Task<DTO> GetByIdAsync(Guid id);

        Task AddAsync(DTO model);

        Task UpdateAsync(DTO model);

        Task DeleteByIdAsync(Guid modelId);
    }
}
