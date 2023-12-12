using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class TransactionService : ITransactionService
{
    #region Private Field
    private List<Transaction> transactions;
    #endregion
    #region CTOR
    public TransactionService()
    {
        transactions = new List<Transaction>(); 
    }
    #endregion
    #region Methods
    public void Create(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public List<Transaction> GetAllByCardId(int cardId)
        => transactions.FindAll(transaction => transaction.CardId == cardId);

    public List<Transaction> GetAllByCustomerId(int customerId)
        => transactions.FindAll(transaction => transaction.CustomerId == customerId);

    public List<Transaction> GetAllByType(TransactionType transactionType)
        => transactions.FindAll(transaction => transaction.Type.Equals(transactionType));

    public Transaction GetById(int id)
        => transactions.FirstOrDefault(transaction => transaction.Id == id);
    #endregion
}
