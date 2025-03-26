using PeopleManager.Domain.Interfaces;

namespace PeopleManager.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;
    }
}
