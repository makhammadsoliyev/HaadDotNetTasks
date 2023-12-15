using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ICategoryService
{
    Category Add(Category category);
    Category GetById(int id);
    void Update(int id, Category category);
    bool Delete(int id);
    List<Category> GetAll();
}
