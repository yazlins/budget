namespace budget.Controllers;

using budget.Data;
using budget.Models;
using Microsoft.AspNetCore.Mvc;

public class RegistersController : Controller
{
    public RegistersController(BudgetDbContext database)
    {
        this.database = database;
    }

    private readonly BudgetDbContext database;

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name", "Username", "Password, ConfirmPassword")] User user)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(user);

            database.Users.Add(user);
            await database.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return View(user);
        }
    }
}

