namespace ExpenseTracker.Models;

public class Expense
{
    private static int id = 0;
    public Expense()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; }
}
