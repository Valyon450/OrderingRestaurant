using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork<PriceListNote> _unit;
        private readonly IMapper _mapper;

        public MenuService(IUnitOfWork<PriceListNote> unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<PriceListNoteDTO> GetAllPriceListNotes()
        {
            var notes = _unit.Repository.GetAll();

            return _mapper.Map<IEnumerable<PriceListNoteDTO>>(notes);
        }

        public async Task AddPriceListNoteAsync(PriceListNoteDTO model)
        {
            // PriceListNoteValidation.CheckPriceListNote(model);

            var note = _mapper.Map<PriceListNote>(model);

            await _unit.Repository.AddAsync(note);
            await _unit.SaveAsync();

            model.Id = note.Id;
        }

        public async Task<PriceListNoteDTO> GetPriceListNoteByIdAsync(Guid id)
        {
            var note = await _unit.Repository.GetByIdAsync(id);

            return _mapper.Map<PriceListNoteDTO>(note);
        }

        public async Task DeletePriceListNoteByIdAsync(Guid modelId)
        {
            await _unit.Repository.DeleteByIdAsync(modelId);
            await _unit.SaveAsync();
        }
    }
}
