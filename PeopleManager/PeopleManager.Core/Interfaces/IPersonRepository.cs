using PeopleManager.Core.Entities;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task SaveAsync(Person employee);
        Task UpdateAsync(Person employee);

        Task<Person> GetByIdAsync(int id);
        Task<IList<Person>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
    }
}