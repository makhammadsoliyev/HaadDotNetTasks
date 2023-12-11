using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface ICardService
{
    void Create(Card card);
    void Update(int id, Card card);
    bool Delete(int id);
    Card GetById(int id);
    Card GetByCustomerId(int customerId);
    Card GetByNumber(string number);
    List<Card> GetAllByType(CardType cardType);
    List<Card> GetAll();
}
