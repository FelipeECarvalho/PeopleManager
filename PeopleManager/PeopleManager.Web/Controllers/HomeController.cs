using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleManager.Application.ViewModels;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PeopleManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _env = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var filePath = Path.Combine(_env.WebRootPath, "images");

            var imagesName = Directory
                .EnumerateFiles(filePath)
                .Select(Path.GetFileName)
                .ToList();

            return View(imagesName);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
