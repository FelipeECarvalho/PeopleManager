﻿using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        [Required]
        public Person Person { get; set; }
    }
}
