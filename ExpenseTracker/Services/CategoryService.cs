using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class CategoryService : ICategoryService
{
    private List<Category> categories;
    private ExpenseService expenseService;
    public CategoryService(ExpenseService expenseService)
    {
        this.categories = new List<Category>();
        this.expenseService = expenseService;
    }

    public Category Add(Category category)
    {
        categories.Add(category);
        return category;
    }

    public bool Delete(int id)
    {
        Category categoryToDelete = categories.FirstOrDefault(category => category.Id == id);
        expenseService.ExpenseList.RemoveAll(expense => expense.Category.Id == categoryToDelete.Id);

        return categories.Remove(categoryToDelete);
    }
    public List<Category> GetAll()
        => categories;

    public List<Expense> GetAllExpensesByCategory(Category category)
        => expenseService.ExpenseList.FindAll(expense => expense.Category.Id == category.Id);

    public Category GetById(int id)
        => categories.Find(category => category.Id == id);

    public Category Update(int id, Category category)
    {
        Category categoryToUpdate = categories.FirstOrDefault(category => category.Id == id);
        categoryToUpdate.Id = id;
        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;

        return categoryToUpdate;
    }
}
