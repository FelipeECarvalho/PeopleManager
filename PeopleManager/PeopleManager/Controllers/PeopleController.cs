using Microsoft.AspNetCore.Mvc;
using PeopleManager.Domain;

namespace PeopleManager.Api.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.Message = TempData["Message"];

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            TempData["Message"] = "Person created successfully!" + string.Format("Name: {0}, Age: {1}", person.Name, person.Age);

            return RedirectToAction("Index");
        }
    }
}
