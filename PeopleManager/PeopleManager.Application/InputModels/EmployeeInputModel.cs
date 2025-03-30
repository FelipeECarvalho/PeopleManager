using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Application.InputModels
{
    public class EmployeeInputModel
    {
        [Required]
        public string Department { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
