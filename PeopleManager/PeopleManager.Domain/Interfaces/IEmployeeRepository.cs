using PeopleManager.Domain.Entities;

namespace PeopleManager.Domain.Interfaces
{
    public  interface IEmployeeRepository
    {
        Task SaveAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task UpdateAsync(Employee employee);

        Task<Employee> GetByIdAsync(int id);
        Task<IList<Employee>> GetAllAsync();

        Task<bool> EmployeeExistsAsync(int id);
    }
}
