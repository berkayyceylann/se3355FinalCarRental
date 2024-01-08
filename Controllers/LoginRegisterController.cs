using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleRentalSystem.Data;
using VehicleRentalSystem.Models;

public class LoginRegisterController : Controller
{
    private readonly CarRentalContext _context;

    public LoginRegisterController(CarRentalContext context)
    {
        _context = context;
    }

    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            if (await EmailAlreadyRegisteredAsync(model.UserEmail))
            {
                ModelState.AddModelError("Email", "This email address is already registered.");
                return View(model);
            }

            await CreateUserAsync(model);
            return RedirectToAction("Index", "Office");
        }

        return View(model);
    }

    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await ValidateUserCredentialsAsync(model);
            if (user != null)
            {
               
                return RedirectToAction("Index", "Office");
            }

            ModelState.AddModelError("", "Invalid email or password.");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        
        return RedirectToAction("Login", "LoginRegister");
    }

    private async Task<bool> EmailAlreadyRegisteredAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.UserEmail == email);
    }

    private async Task CreateUserAsync(RegisterModel model)
    {
        var user = new UserModel
        {
            UserEmail = model.UserEmail,
            UserPassword = model.UserPassword, 
            UserName = model.UserName,
            UserCountry = model.UserCountry,
            UserCity = model.UserCity
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    private async Task<UserModel> ValidateUserCredentialsAsync(LoginModel model)
    {
        return await _context.Users .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail && u.UserPassword == model.UserPassword); 
    }
}
