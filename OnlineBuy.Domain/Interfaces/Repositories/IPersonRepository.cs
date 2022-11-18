using OnlineBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetAllAsync();
        Task<Person> CreateAsync (Person person);
        Task UpdateAsync (Person person);
        Task DeleteAsync (Person person);
    }
}
