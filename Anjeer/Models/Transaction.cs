namespace Anjeer.Models;

public class Transaction
{
    public int Id { get; set; }
    public int CustomerId {  get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public int EmployeeId { get; set; }
    public TransactionType type { get; set; }
}
