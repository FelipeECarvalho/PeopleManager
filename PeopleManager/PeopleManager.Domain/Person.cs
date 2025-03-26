using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Domain
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "O nome deve ser maior que 2 e menor que 10 caracteres")]
        public string Name { get; set; }

        [CustomValidation(typeof(Person), "AgeValidate")]
        public int? Age { get; set; }

        public static ValidationResult AgeValidate(int? age)
        {
            if (age < 18)
            {
                return new ValidationResult("A idade deve ser maior que 18 anos");
            }

            return ValidationResult.Success;
        }
    }
}
