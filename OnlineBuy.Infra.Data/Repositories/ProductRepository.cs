using Microsoft.EntityFrameworkCore;
using OnlineBuy.Domain.Interfaces.Repositories;
using OnlineBuy.Domain.Models;
using OnlineBuy.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();  
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Update(product);
           await _db.SaveChangesAsync();
        }
    }
}
