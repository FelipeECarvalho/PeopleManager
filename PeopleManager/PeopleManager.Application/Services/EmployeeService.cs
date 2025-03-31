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
            Validate(employee);

            await _employeeRepository.SaveAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            Validate(employee);

            if (!await ExistsAsync(employee.Id))
                throw new InvalidOperationException("Employee not found");

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

        private static void Validate(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            if (string.IsNullOrEmpty(employee.Department))
                throw new InvalidOperationException("Department is required");

            if (employee.Salary <= 0)
                throw new InvalidOperationException("Salary is required");

            if (employee.PersonId == 0)
                throw new InvalidOperationException("Person is required");
        }
    }
}