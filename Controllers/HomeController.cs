using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly ApplicationDbContext _context;

        readonly ApplicationDbContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
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