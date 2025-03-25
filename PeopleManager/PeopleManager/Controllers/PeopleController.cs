using Microsoft.AspNetCore.Mvc;

namespace PeopleManager.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }
    }
}
