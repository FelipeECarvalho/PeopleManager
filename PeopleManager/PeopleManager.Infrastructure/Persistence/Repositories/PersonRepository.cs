﻿using Microsoft.EntityFrameworkCore;
using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Infrastructure.Persistence.Repositories
{
    public class PersonRepository(PeopleManagerContext _context) : IPersonRepository
    {
        public async Task<IList<Person>> GetAllAsync()
        {
            return await _context.Person
                .Where(x => !x.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Person
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Person
                .Where(x => !x.IsDeleted)
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);
        }
    }
}