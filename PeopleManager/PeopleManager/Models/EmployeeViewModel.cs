using PeopleManager.Domain.Entities;

namespace PeopleManager.Api.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
