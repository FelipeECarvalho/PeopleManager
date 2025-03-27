using Microsoft.EntityFrameworkCore;
using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Persistence.Repositories
{
    public class EmployeeRepository(PeopleManagerContext context) : IEmployeeRepository
    {
        private readonly PeopleManagerContext _context = context;

        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<bool> EmployeeExistsAsync(int id)
        {
            return await _context.Employee.AnyAsync(x => x.Id == id);
        }
    }
}
