using PeopleManager.Core.Enums;

namespace PeopleManager.Core.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Document { get; set; }
        public EBloodType BloodType { get; set; }
    }
}