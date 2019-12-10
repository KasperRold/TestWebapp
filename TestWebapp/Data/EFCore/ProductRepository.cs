using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebapp.Models;

namespace TestWebapp.Data.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestDbContext _context;

        public ProductRepository(TestDbContext context)
        {
            this._context = context;
        }

        public async Task<Product> Add(Product product)
        {
            _context.Set<Product>().Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var entity = await _context.Set<Product>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<Product>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}