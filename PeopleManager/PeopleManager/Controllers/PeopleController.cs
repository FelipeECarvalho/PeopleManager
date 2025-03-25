using Microsoft.AspNetCore.Mvc;
using PeopleManager.Models;

namespace PeopleManager.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index(string name)
        {
            var personList = new List<Person>()
            {
                new() { Name = "John Doe", Age = 14 },
                new() { Name = "Marcus", Age = 15 },
                new() { Name = "Felipe", Age = 20 },
                new() { Name = "Test", Age = 23 }
            };

            var person = personList.FirstOrDefault(p => p.Name == name);

            return View(person);
        }

        public IActionResult Details()
        {
            ViewBag.Date = DateTime.Now.ToShortDateString();
            ViewBag.Text = "Welcome!";

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
