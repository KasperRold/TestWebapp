using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TestWebapp.Models;

namespace TestWebapp.Test
{
    [TestFixture]
    public class ProductControllerIntegrationTests
    {
        private ApiWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:44349/");
        }

        [Test]
        public async Task GetProduct()
        {
            var productId = 1;

            var result = await _client.GetAsync($"api/product/{productId}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PostProduct()
        {
            var product = new Product()
            {
                Name = "testproduct",
                Sku = "testsku",
                Price = 100
            };
            var json = JsonConvert.SerializeObject(product);
            var textContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
            textContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _client.PostAsync($"api/product", textContent);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}