using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation.Order;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork<Order> _unit;
        private readonly IUnitOfWork<OrderItem> _unitOrderItem;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork<Order> unit, IUnitOfWork<OrderItem> unitOrderItem, IMapper mapper)
        {
            _unit = unit;
            _unitOrderItem = unitOrderItem;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _unit.Repository.GetAll();  

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task AddAsync(OrderDTO model)
        {
            OrderValidation.CheckOrder(model);

            var order = _mapper.Map<Order>(model);

            await _unit.Repository.AddAsync(order);
            await _unit.SaveAsync();

            model.Id = order.Id;
        }

        public async Task<OrderDTO> GetByIdAsync(Guid id)
        {
            var order = await _unit.Repository.GetByIdAsync(id);

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task UpdateAsync(OrderDTO model)
        {
            OrderValidation.CheckOrder(model);
            var existingOrder = await _unit.Repository.GetByIdAsync(model.Id);

            if (existingOrder != null)
            {
                _mapper.Map(model, existingOrder);

                await _unit.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(Guid modelId)
        {
            await _unit.Repository.DeleteByIdAsync(modelId);
            await _unit.SaveAsync();
        }

        public IEnumerable<OrderItemDTO> GetOrderItems(Guid orderId)
        {
            var orderItems = _unitOrderItem.Repository.GetAll()
                .Where(orderItem => orderItem.OrderId == orderId);

            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }

        public async Task AddOrderItemAsync(OrderItemDTO model)
        {
            var orderItem = _mapper.Map<OrderItem>(model);

            await _unitOrderItem.Repository.AddAsync(orderItem);
            await _unitOrderItem.SaveAsync();

            model.Id = orderItem.Id;
        }

        public async Task DeleteOrderItemByIdAsync(Guid modelId)
        {
            await _unitOrderItem.Repository.DeleteByIdAsync(modelId);
            await _unitOrderItem.SaveAsync();
        }
    }
}
