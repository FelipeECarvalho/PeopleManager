using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Interfaces;

namespace PeopleManager.Application.Services
{
    public class PersonService(IPersonRepository _personRepository)
    {
        public async Task<IList<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync(Person person)
        {
            await _personRepository.SaveAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            await _personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(Person person)
        {
            await _personRepository.DeleteAsync(person);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _personRepository.ExistsAsync(id);
        }
    }
}
