using Microsoft.EntityFrameworkCore;
using DealershipExpenseTracker.Models;

namespace DealershipExpenseTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}