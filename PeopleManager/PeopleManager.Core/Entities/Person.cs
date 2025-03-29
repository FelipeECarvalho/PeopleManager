using PeopleManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Core.Entities
{
    public class Person : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public EBloodType BloodType { get; set; }
    }
}