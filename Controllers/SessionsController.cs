namespace budget.Controllers;

using budget.Data;
using budget.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SessionsController : Controller
{
    public SessionsController(BudgetDbContext database)
    {
        this.database = database;
    }

    private readonly BudgetDbContext database;

    public IActionResult Login() => View(new Session());

    [HttpPost]
    public async Task<IActionResult> Login([Bind("Username", "Password")] Session session)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(session);

            var user = await database.Users.FirstOrDefaultAsync(x => x.Username == session.Username && x.Password == session.Password);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "User not found. Please try again.");
                return View(session);
            }

            HttpContext.Session.GetInt32(user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return View(session);
        }
    }

    public IActionResult Logout()
    {
        try
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return RedirectToAction("Index", "Home");
        }
    }   
}

