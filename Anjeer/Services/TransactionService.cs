using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class TransactionService : ITransactionService
{
    private List<Transaction> transactions;
    public TransactionService()
    {
        transactions = new List<Transaction>();
    }
    public void Create(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public List<Transaction> GetAllByCardId(int cardId)
        => transactions.FindAll(transaction => transaction.CardId == cardId);

    public List<Transaction> GetAllByCustomerId(int customerId)
        => transactions.FindAll(transaction => transaction.CustomerId == customerId);

    public List<Transaction> GetAllByType(TransactionType transactionType)
        => transactions.FindAll(transaction => transaction.Type == transactionType);

    public Transaction GetById(int id)
        => transactions.FirstOrDefault(transaction => transaction.Id == id);
}
