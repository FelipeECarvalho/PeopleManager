using PeopleManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "The name property must have more than 2 and less than 10 characters")]
        public string Name { get; set; }

        [CustomValidation(typeof(Person), "AgeValidate")]
        public int? Age { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The document property must have 11 characters")]
        public string Document { get; set; }

        public EBloodType BloodType { get; set; }

        public static ValidationResult AgeValidate(int? age)
        {
            if (age < 18)
                return new ValidationResult("A idade deve ser maior que 18 anos");

            return ValidationResult.Success;
        }
    }
}
