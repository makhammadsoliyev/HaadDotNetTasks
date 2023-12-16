using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ICategoryService
{
    Category Add(Category category);
    Category GetById(int id);
    List<Expense> GetAllExpensesByCategory(Category category);
    Category Update(int id, Category category);
    bool Delete(int id);
    List<Category> GetAll();
}
