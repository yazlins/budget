namespace budget.Controllers;

using budget.Data;
using budget.Models;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    public UsersController(BudgetDbContext database)
    {
        this.database = database;
    }

    private readonly BudgetDbContext database;

    public IActionResult Index()
    {
        var users = database.User.ToList();
        return View(users);
    }

    public IActionResult Create()
    {
        return View(new User());
    }

    [HttpPost]
    public IActionResult Create([Bind("Name", "Username", "Password")] User user)
    {
        if (ModelState.IsValid)
        {
            database.User.Add(user);
            database.User.SaveChanges();
            return RedirectToAction("Index");
        }
        
        return View(user);
    }

}

