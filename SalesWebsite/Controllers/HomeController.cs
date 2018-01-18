using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Models;
using SalesWebsite.ViewModels;
using Microsoft.AspNetCore.Identity;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }
        public IActionResult Sum(int firstNumber, int secondNumber)
        {
            return Content((firstNumber + secondNumber).ToString(), "text/plain");
        }
        public IActionResult DisplayObject()
        {
            Temp destination = new Temp("Tokyo", "Japan", 1);
            return Json(destination);
        }
        public IActionResult DisplayViewWithAjax()
        {
            return View();
        }
        public IActionResult RandomDestinationList(int destinationCount)
        {
            var randomDestinationList = _db.Temps.OrderBy(r => Guid.NewGuid()).Take(destinationCount);
            return Json(randomDestinationList);
        }

        [HttpPost]
        public IActionResult NewDestination(string newCity, string newCountry)
        {
            Temp newDestination = new Temp(newCity, newCountry);
            _db.Temps.Add(newDestination);
            _db.SaveChanges();
            return Json(newDestination);
        }
    }
}
