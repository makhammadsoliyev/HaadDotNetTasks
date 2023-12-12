using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class CardService : ICardService
{
    #region Private Field
    private List<Card> cards;
    #endregion
    #region CTOR
    public CardService()
    {
        cards = new List<Card>();
    }
    #endregion
    #region Methods
    public void Create(Card card)
    {
        cards.Add(card);
    }

    public bool Delete(int id)
        => cards.Remove(GetById(id));

    public List<Card> GetAll()
        => cards;

    public List<Card> GetAllByType(CardType cardType)
        => cards.FindAll(card => card.Type.Equals(cardType));

    public Card GetByCustomerId(int customerId)
        => cards.FirstOrDefault(card => card.CustomerId.Equals(customerId));

    public Card GetById(int id)
        => cards.FirstOrDefault(card => card.Id.Equals(id));

    public Card GetByNumber(string number)
        => cards.FirstOrDefault(card => card.Number.Equals(number));

    public void Update(int id, Card card)
    {
        var cardToUpdate = GetById(id);
        cardToUpdate.Id = id;
        cardToUpdate.Type = card.Type;
        cardToUpdate.Number = card.Number;
        cardToUpdate.Balance = card.Balance;
        cardToUpdate.Password = card.Password;
        cardToUpdate.CustomerId = card.CustomerId;
        cardToUpdate.ExpireDate = card.ExpireDate;
    }
    #endregion 
}
