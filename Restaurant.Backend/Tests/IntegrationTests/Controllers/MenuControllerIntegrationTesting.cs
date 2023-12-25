using BusinessLogic.DTO;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class MenuControllerIntegrationTesting : IntegrationTesting
    {
        public MenuControllerIntegrationTesting(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReadAll_ReturnsOkResult()
        {
            // Arrange

            //Act
            var response = await client.GetAsync("/api/menu");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReadById_ReturnsNotFound()
        {
            // Arrange
            var Id = Guid.Empty;

            // Act
            var response = await client.GetAsync($"/api/menu/{Id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsCreated()
        {
            // Arrange
            var priceListNote = new PriceListNoteDTO
            {
                DishId = Guid.NewGuid(),
                PortionSize = "TestingPortionSize",
                Price = 100
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/menu", priceListNote);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var addedNote = await context.PriceListNotes.FirstOrDefaultAsync(d => d.PortionSize == priceListNote.PortionSize);
            Assert.NotNull(addedNote);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var priceListNote = new PriceListNote
            {
                DishId = Guid.NewGuid(),
                PortionSize = "DeleteTestingPortionSize",
                Price = 100
            };
            context.PriceListNotes.Add(priceListNote);
            await context.SaveChangesAsync();
            var deletedNote = await context.PriceListNotes.FirstOrDefaultAsync(d => d.PortionSize == priceListNote.PortionSize);

            // Act
            var response = await client.DeleteAsync($"/api/menu/{deletedNote.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
