namespace BankingSystem.Models;

public class Account
{
    private static int id = 0;

    public Account()
    {
        this.Id = ++id;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public string Number { get; set; }
}
