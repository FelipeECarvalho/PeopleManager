using PeopleManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Domain.Interfaces
{
    public  interface IPersonRepository
    {
        Task SaveAsync(Person employee);
        Task DeleteAsync(Person employee);
        Task UpdateAsync(Person employee);

        Task<Person> GetByIdAsync(int id);
        Task<IList<Person>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
    }
}
