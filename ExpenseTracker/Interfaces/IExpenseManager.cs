using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface IExpenseManager
{
    decimal CalculateTotalExpenses();
    List<Expense> ExpensesByCategory(Category category);
}
