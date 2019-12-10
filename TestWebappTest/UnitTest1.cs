using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestWebapp.Controllers;
using TestWebapp.Data;
using TestWebapp.Data.EFCore;
using TestWebapp.Models;

namespace TestWebapp.Test
{
    public class ProductControllerTests
    {

        [Test]
        public async Task PricesAddUpCorrectly()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(GetTestData);
            var controller = new ProductController(mockRepo.Object);

            //Act
            var expected = 19.99 + 12.99;
            var actual = await controller.GetTotalPrice();
           
            //Assert
            Assert.AreEqual(expected, actual);
            
        }

        private List<Product> GetTestData()
        {
            var testData = new List<Product>();
            testData.Add(new Product()
            {
                Id = 1,
                Name = "Ost",
                Sku = "brie-1",
                Price = 19.99
            });
            testData.Add(new Product()
            {
                Id = 2,
                Name = "Smør",
                Sku = "lurpak-1",
                Price = 12.99
            });
            return testData;
        }
    }
}