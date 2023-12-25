using BusinessLogic.DTO;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class DishControllerIntegrationTesting : IntegrationTesting
    {
        public DishControllerIntegrationTesting(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReadAll_ReturnsOkResult()
        {
            // Arrange

            //Act
            var response = await client.GetAsync("/api/dish");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReadById_ReturnsNotFound()
        {
            // Arrange
            var Id = Guid.Empty;

            // Act
            var response = await client.GetAsync($"/api/dish/{Id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsCreated()
        {
            // Arrange
            var dish = new DishDTO
            {
                Name = "TestingName",
                Description = "TestingDescription",
                Ingredients = new List<IngredientDTO>()
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/dish", dish);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var addedDish = await context.Dishes.FirstOrDefaultAsync(d => d.Name == dish.Name);
            Assert.NotNull(addedDish);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var dish = new Dish
            {
                Name = "DeleteTestingName",
                Description = "DeleteTestingDescription"
            };
            context.Dishes.Add(dish);
            await context.SaveChangesAsync();
            var deletedDish = await context.Dishes.FirstOrDefaultAsync(d => d.Name == dish.Name);

            // Act
            var response = await client.DeleteAsync($"/api/dish/{deletedDish.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
