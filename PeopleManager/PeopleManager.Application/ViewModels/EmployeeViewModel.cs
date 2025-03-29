using PeopleManager.Core.Entities;
using System.Collections.Generic;

namespace PeopleManager.API.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
