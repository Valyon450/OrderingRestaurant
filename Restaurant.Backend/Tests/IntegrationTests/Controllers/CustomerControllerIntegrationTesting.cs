using BusinessLogic.DTO;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class CustomerControllerIntegrationTesting : IntegrationTesting
    {
        public CustomerControllerIntegrationTesting(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReadAll_ReturnsOkResult()
        {
            // Arrange

            //Act
            var response = await client.GetAsync("/api/customer");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReadById_ReturnsNotFound()
        {
            // Arrange
            var Id = Guid.Empty;

            // Act
            var response = await client.GetAsync($"/api/customer/{Id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsCreated()
        {
            // Arrange
            var customer = new CustomerDTO
            {
                SurName = "TestingSurName",
                Name = "TestingName"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/customer", customer);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var addedCustomer = await context.Customers.FirstOrDefaultAsync(d => d.SurName == customer.SurName);
            Assert.NotNull(addedCustomer);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var customer = new Customer
            {
                SurName = "DeleteTestingSurName",
                Name = "DeleteTestingName"
            };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            var deletedCustomer = await context.Customers.FirstOrDefaultAsync(d => d.SurName == customer.SurName);

            // Act
            var response = await client.DeleteAsync($"/api/customer/{deletedCustomer.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
