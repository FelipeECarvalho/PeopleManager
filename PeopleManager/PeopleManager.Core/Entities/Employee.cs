namespace PeopleManager.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}