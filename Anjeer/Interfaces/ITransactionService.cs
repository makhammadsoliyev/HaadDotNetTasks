using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface ITransactionService
{
    void Create(Transaction transaction);
    Transaction GetById(int id);
    List<Transaction> GetAllByCardId(int cardId);
    List<Transaction> GetAllByCustomerId(int customerId);
    List<Transaction> GetAllByType(TransactionType transactionType);
}
