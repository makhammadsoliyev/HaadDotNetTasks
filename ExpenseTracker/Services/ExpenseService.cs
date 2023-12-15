using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class ExpenseService : IExpenseService, IExpenseManager
{
    private List<Expense> expenseList;

    public List<Expense> ExpenseList { get; set; }

    public ExpenseService()
    {
        expenseList = new List<Expense>();
        ExpenseList = expenseList;
    }

    public Expense Add(Expense expense)
    {
        expenseList.Add(expense);
        return expense;
    }

    public bool Delete(int id)
        => expenseList.Remove(expenseList.FirstOrDefault(expense => expense.Id == id));

    public List<Expense> GetAll()
        => expenseList;

    public Expense GetById(int id)
        => expenseList.FirstOrDefault(expense => expense.Id == id);

    public void Update(int id, Expense expense)
    {
        Expense expenseToUpdate = expenseList.FirstOrDefault(expense => expense.Id == id);
        expenseToUpdate.Id = id;
        expenseToUpdate.Date = expense.Date;
        expenseToUpdate.Category = expense.Category;
        expenseToUpdate.Description = expense.Description;
    }

    public decimal CalculateTotalExpenses()
        => expenseList.Sum(expense => expense.Amount);

    public List<Expense> ExpensesByCategory(Category category)
        => expenseList.FindAll(expense => expense.Category.Id == category.Id);
}
