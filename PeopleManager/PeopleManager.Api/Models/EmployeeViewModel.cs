using PeopleManager.Core.Entities;

namespace PeopleManager.API.Models
{
    public class EmployeeViewModel
    {
        public int? PersonId { get; set; }
        public Employee Employee { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
