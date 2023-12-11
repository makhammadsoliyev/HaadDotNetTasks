namespace Anjeer.Models;

public class Card
{
    public int Id { get; set; }
    public CardType type { get; set; }
    public string Number { get; set; }
    public DateOnly ExpireDate { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public int CustomerId { get; set; }
}
