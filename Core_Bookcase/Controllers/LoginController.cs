using Core_Bookcase.Data;
using Core_Bookcase.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_Bookcase.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var bilgi=_context.Admins.FirstOrDefault(x=>x.Name== admin.Name && x.Password==admin.Password);
            if (bilgi!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Name),
                };
                var userIdentity=new ClaimsIdentity(claims, "Login");
				await HttpContext.SignInAsync(new ClaimsPrincipal(userIdentity));
				return RedirectToAction("Index", "Admin");
			}
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View(admin);
        }
    }
}
