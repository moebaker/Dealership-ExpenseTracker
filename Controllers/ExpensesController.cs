using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipExpenseTracker.Data;
using DealershipExpenseTracker.Models;

namespace DealershipExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index(string categoryFilter)
        {
            var expenses = _context.Expenses.AsQueryable();

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                expenses = expenses.Where(e => e.Category == categoryFilter);
            }

            var categories = await _context.Expenses
                .Select(e => e.Category)
                .Distinct()
                .ToListAsync();

            ViewBag.Categories = categories;
            return View(await expenses.ToListAsync());
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description,Amount,Category,Date")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }
    }
}