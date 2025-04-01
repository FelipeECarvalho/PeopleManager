using Microsoft.EntityFrameworkCore;
using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository(PeopleManagerContext _context) : IEmployeeRepository
    {
        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _context.Employee
                .Include(x => x.Person)
                .Where(x => !x.IsDeleted && !x.Person.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Employee>> GetByNameAsync(string name)
        {
            return await _context.Employee
                .Include(x => x.Person)
                .Where(x => !x.IsDeleted && !x.Person.IsDeleted)
                .Where(x => EF.Functions.Like(x.Person.Name, $"%{name}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee
                .Include(x => x.Person)
                .Where(x => !x.IsDeleted && !x.Person.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            employee.Person = null;
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employee
                .Where(x => !x.IsDeleted && !x.Person.IsDeleted)
                .AsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
    }
}