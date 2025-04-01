using PeopleManager.Core.Entities;

namespace PeopleManager.Application.Services
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetAllAsync();

        Task<IList<Employee>> GetByNameAsync(string name);

        Task<Employee> GetByIdAsync(int id);

        Task SaveAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(Employee employee);

        Task<bool> ExistsAsync(int id);
    }
}
