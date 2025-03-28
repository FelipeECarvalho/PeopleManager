using Microsoft.EntityFrameworkCore;
using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Persistence.Repositories
{
    public class PersonRepository(PeopleManagerContext _context) : IPersonRepository
    {
        public async Task<IList<Person>> GetAllAsync()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Person.FindAsync(id);
        }

        public async Task SaveAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Person.AnyAsync(e => e.Id == id);
        }
    }
}
