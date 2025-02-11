using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipExpenseTracker.Data;
using DealershipExpenseTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DealershipExpenseTracker.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Calculate the total amount for each category
            var reportData = await _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new ExpenseReportViewModel
                {
                    Category = g.Key,
                    TotalAmount = g.Sum(e => e.Amount),
                    ExpenseCount = g.Count()
                })
                .ToListAsync();

            // Calculate the total of all expenses
            decimal totalExpenses = await _context.Expenses.SumAsync(e => e.Amount);

            // Pass the total expenses to the ViewBag to display in the view
            ViewBag.TotalExpenses = totalExpenses;

            return View(reportData);
        }
    }
}
