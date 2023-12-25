using BusinessLogic.DTO;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class OrderControllerIntegrationTesting : IntegrationTesting
    {
        public OrderControllerIntegrationTesting(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReadAll_ReturnsOkResult()
        {
            // Arrange

            //Act
            var response = await client.GetAsync("/api/order");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReadById_ReturnsNotFound()
        {
            // Arrange
            var Id = Guid.Empty;

            // Act
            var response = await client.GetAsync($"/api/order/{Id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsCreated()
        {
            // Arrange
            var order = new OrderDTO
            {
                CustomerId = Guid.NewGuid(),
                Details = "TestingDetails",
                TotalOrderAmount = 1000,
                OrderDateTime = DateTime.Today,
                EditDateTime = DateTime.Today,
                OrderItems = new List<OrderItemDTO>()
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/order", order);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var addedOrder = await context.Orders.FirstOrDefaultAsync(d => d.Details == order.Details);
            Assert.NotNull(addedOrder);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                Details = "DeleteTestingDetails",
                TotalOrderAmount = 1000,
                OrderDateTime = DateTime.Today,
                EditDateTime = DateTime.Today
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            var deletedOrder = await context.Orders.FirstOrDefaultAsync(d => d.Details == order.Details);

            // Act
            var response = await client.DeleteAsync($"/api/order/{deletedOrder.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
