using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebapp.Models;

namespace TestWebapp.Data
{

    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> Get(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);

    }
}