using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class CategoryService : ICategoryService
{
    private List<Category> categories;
    public List<Category> Categories { get; set; }

    public CategoryService()
    {
        categories = new List<Category>();
        Categories = categories;
    }

    public Category Add(Category category)
    {
        categories.Add(category);
        return category;
    }

    public bool Delete(int id)
        => categories.Remove(categories.Find(category => category.Id == id));

    public List<Category> GetAll()
        => categories;

    public Category GetById(int id)
        => categories.Find(category => category.Id == id);

    public void Update(int id, Category category)
    {
        Category categoryToUpdate = categories.Find(category => category.Id == id);
        categoryToUpdate.Id = id;
        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
    }
}
