namespace Anjeer.Models;

public class Transaction
{
    #region Private Field
    private static int _id = 0;
    #endregion
    #region CTOR
    public Transaction()
    {
        Id = ++_id;
    }
    #endregion
    #region Properties
    public int Id { get; set; }
    public int CustomerId {  get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public int EmployeeId { get; set; }
    public TransactionType Type { get; set; }
    #endregion
}
