namespace budget.Controllers;

using budget.Data;
using budget.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminUsersController : Controller
{
    public AdminUsersController(BudgetDbContext database)
    {
        this.database = database;
    }

    private readonly BudgetDbContext database;

    public async Task<IActionResult> Index() => View(await database.Users.ToListAsync());
    public async Task<IActionResult> Details(int id) => View(await database.Users.FindAsync(id));

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name", "Username", "Password", "ConfirmPassword")] User user)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(user);

            database.Users.Add(user);
            await database.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return View(user);
        }
    }

    public async Task<IActionResult> Edit(int id) => View(await database.Users.FindAsync(id));

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Name", "Username", "Password", "ConfirmPassword")] User user)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(user);

            database.Users.Update(user);
            await database.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return View(user);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var user = await database.Users.FindAsync(id);

            if (user is null)
                return RedirectToAction("Index");

            database.Users.Remove(user);
            await database.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.StackTrace ?? "An unknown error occurred.");
            return RedirectToAction("Index");
        }
    }
}

