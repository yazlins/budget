namespace budget.Data;

using Microsoft.EntityFrameworkCore;
using budget.Models;

public class BudgetDbContext : DbContext
{
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
}

