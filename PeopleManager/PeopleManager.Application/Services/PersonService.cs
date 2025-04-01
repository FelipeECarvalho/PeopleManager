using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

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
            Validate(person);

            person.UpdateDate = DateTime.Now;
            person.CreateDate = DateTime.Now;

            await _personRepository.SaveAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            Validate(person);

            if (!await ExistsAsync(person.Id))
                throw new InvalidOperationException("Person not found");

            person.UpdateDate = DateTime.Now;

            await _personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(Person person)
        {
            person.UpdateDate = DateTime.Now;
            person.IsDeleted = true;

            await _personRepository.UpdateAsync(person);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _personRepository.ExistsAsync(id);
        }

        private static void Validate(Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            if (string.IsNullOrEmpty(person.Document))
                throw new InvalidOperationException("Document is required");

            if (string.IsNullOrEmpty(person.Name))
                throw new InvalidOperationException("Name is required");

            if (person.Age == 0)
                throw new InvalidOperationException("Age is required");
        }
    }
}