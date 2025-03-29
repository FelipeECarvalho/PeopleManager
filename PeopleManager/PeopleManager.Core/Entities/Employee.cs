using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Core.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public string Department { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}