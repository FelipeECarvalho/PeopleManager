using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync(Employee employee)
        {
            await _employeeRepository.SaveAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(Employee employee)
        {
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _employeeRepository.ExistsAsync(id);
        }
    }
}