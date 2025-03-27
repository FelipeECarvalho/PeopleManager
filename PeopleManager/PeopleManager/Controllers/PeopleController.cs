using Microsoft.AspNetCore.Mvc;
using PeopleManager.Domain.Entities;

namespace PeopleManager.Api.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index(string name)
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            return View();
        }
    }
}
