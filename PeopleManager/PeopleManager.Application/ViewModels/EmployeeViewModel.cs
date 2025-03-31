using PeopleManager.Core.Entities;

namespace PeopleManager.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
