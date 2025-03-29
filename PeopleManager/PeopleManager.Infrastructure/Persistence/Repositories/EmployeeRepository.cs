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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employee
                .AsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
    }
}