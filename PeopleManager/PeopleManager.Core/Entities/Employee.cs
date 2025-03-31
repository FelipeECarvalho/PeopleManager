using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}