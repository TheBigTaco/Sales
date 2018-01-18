using SalesWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SalesWebsite.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }    
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var role = new ApplicationRole
            {
                Name = collection["RoleName"]
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            _db.SaveChanges();
            ViewBag.ResultMessage = "Role created successfully !";
            return RedirectToAction("Role");
        }

        public IActionResult Role()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public ActionResult Edit(string roleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name == roleName).FirstOrDefault();

            return View(thisRole);
        }

        //TODO: THIS IS SO BROKEN DON'T EVEN TRY AAAARRRRGGGHHH
        //TODO: Delete Role and Create Edited Role, EntityStateChange does not work
        // POST: /Roles/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole role)
        //{
        //    try
        //    {
        //        var thisRole = _db.Roles.Where(r => r.Name.Equals).FirstOrDefault();
        //        _db.Roles.Remove(thisRole);
        //        _db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}