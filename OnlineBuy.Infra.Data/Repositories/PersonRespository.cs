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
    public class PersonRespository : IPersonRepository
    {
        private readonly ApplicationContext _db;
        public PersonRespository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }
    }
}
