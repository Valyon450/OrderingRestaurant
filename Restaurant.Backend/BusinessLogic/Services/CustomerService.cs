using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork<Customer> _unit;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork<Customer> unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _unit.Repository.GetAll();

            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task AddAsync(CustomerDTO model)
        {
            // CustomerValidation.CheckCustomer(model);

            var customer = _mapper.Map<Customer>(model);

            await _unit.Repository.AddAsync(customer);
            await _unit.SaveAsync();

            model.Id = customer.Id;
        }

        public async Task<CustomerDTO> GetByIdAsync(Guid id)
        {
            var customer = await _unit.Repository.GetByIdAsync(id);

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task UpdateAsync(CustomerDTO model)
        {
            // CustomerValidation.CheckCustomer(model);

            var existingCustomer = await _unit.Repository.GetByIdAsync(model.Id);

            if (existingCustomer != null)
            {
                _mapper.Map(model, existingCustomer);

                await _unit.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(Guid modelId)
        {
            await _unit.Repository.DeleteByIdAsync(modelId);
            await _unit.SaveAsync();
        }
    }
}
