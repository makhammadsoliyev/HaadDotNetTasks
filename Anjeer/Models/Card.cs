namespace Anjeer.Models;

public class Card
{
    #region Private Field
    private static int _id = 0;
    #endregion
    #region CTOR
    public Card()
    {
        Id = ++_id;
    }
    #endregion
    #region Properties
    public int Id { get; set; }
    public CardType Type { get; set; }
    public string Number { get; set; }
    public DateOnly ExpireDate { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public int CustomerId { get; set; }
    #endregion
}
