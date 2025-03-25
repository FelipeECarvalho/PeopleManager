using Microsoft.AspNetCore.Mvc;
using PeopleManager.Models;

namespace PeopleManager.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var personList = new List<Person>()
            {
                new() { Name = "John Doe", Age = 14 },
                new() { Name = "Marcus", Age = 15 },
                new() { Name = "Felipe", Age = 20 },
                new() { Name = "Test", Age = 23 }
            };

            return View(personList);
        }
    }
}
