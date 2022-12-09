using basicWebApp.Data;
using basicWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace basicWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HRDbContext context; 

        public HomeController(ILogger<HomeController> logger, HRDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}