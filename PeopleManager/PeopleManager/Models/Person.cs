using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Age { get; set; }
    }
}
