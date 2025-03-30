using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Core.Entities
{
    public class Employee : BaseEntity
    {
        public Employee(string department, decimal salary, int personId)
        {
            Department = department;
            Salary = salary;
            PersonId = personId;
        }

        [Required]
        public string Department { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}