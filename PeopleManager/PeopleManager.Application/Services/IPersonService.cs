using PeopleManager.Core.Entities;

namespace PeopleManager.Application.Services
{
    public interface IPersonService
    {
        Task<IList<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);

        Task SaveAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);

        Task<bool> ExistsAsync(int id);
    }
}
