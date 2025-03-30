using PeopleManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Application.InputModels
{
    public class PersonInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Document { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public EBloodType BloodType { get; set; }
    }
}
