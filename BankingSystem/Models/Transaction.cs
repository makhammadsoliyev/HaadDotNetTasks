namespace BankingSystem.Models;

public class Transaction
{
    private static int id = 0;

    public Transaction()
    {
        this.Id = ++id;
    }

    public int Id { get; set; }
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
}
