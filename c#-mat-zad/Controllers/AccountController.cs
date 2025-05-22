using Microsoft.AspNetCore.Mvc;
using NotesAppAspNet.Data;
using NotesAppAspNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using c__mat_zad.Models;
namespace NotesAppAspNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _context.Users.AnyAsync(u => u.Username == model.Username))
            {
                ModelState.AddModelError("", "Uživatel už existuje.");
                return View(model);
            }

            if (!model.Consent)
            {
                ModelState.AddModelError("Consent", "Musíš souhlasit s podmínkami.");
                return View(model);
            }


            var user = new User { Username = model.Username };
            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (user == null ||
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Neplatné přihlašovací údaje.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Note");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Account");
        }

    }
}
