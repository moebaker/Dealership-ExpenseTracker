using System;
using System.ComponentModel.DataAnnotations;

namespace DealershipExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty; // e.g., Marketing, Travel, Client Meetings

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        // Optional: Track salesperson (for future authentication)
        public string SalesPersonId { get; set; } = string.Empty;
    }
}
