using OnlineBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> CreateAsync (Product product); 
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
