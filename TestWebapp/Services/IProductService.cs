using System.Collections.Generic;
using TestWebapp.Models;

namespace TestWebapp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}