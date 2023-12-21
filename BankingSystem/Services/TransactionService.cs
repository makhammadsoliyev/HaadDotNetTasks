using BankingSystem.Interfaces;
using BankingSystem.Models;

namespace BankingSystem.Services;

public class TransactionService : ITransactionService
{
    private readonly List<Transaction> transactions;
    private readonly AccountService accountService;

    public TransactionService(AccountService accountService)
    {
        this.transactions = new List<Transaction>();
        this.accountService = accountService;
    }

    public Transaction DepositFunds(Transaction transaction)
    {
        var account = accountService.GetById(transaction.ReceiverAccountId);

        account.Balance += transaction.Amount;
        
        transactions.Add(transaction);
        return transaction;
    }

    public List<Transaction> GetAll()
        => transactions;

    public Transaction GetById(int id)
    {
        var transaction = transactions.FirstOrDefault(t => t.Id == id)
            ?? throw new Exception("Transaction with this id was not found...");

        return transaction;
    }

    public List<Transaction> GetTransactionHistory(int accountId)
        => transactions.Where(t => t.ReceiverAccountId == accountId || t.SenderAccountId == accountId).ToList();

    public Transaction PerformFundTransfer(Transaction transaction)
    {
        var senderAccount = accountService.GetById(transaction.SenderAccountId);
        var receiverAccount = accountService.GetById(transaction.ReceiverAccountId);

        if (senderAccount.Balance < transaction.Amount)
            throw new Exception("It does not have enough money to transfer...");

        senderAccount.Balance -= transaction.Amount;
        receiverAccount.Balance += transaction.Amount;

        transactions.Add(transaction);
        return transaction;
    }

    public Transaction WithdrawFunds(Transaction transaction)
    {
        var account = accountService.GetById(transaction.SenderAccountId);

        if (account.Balance < transaction.Amount)
            throw new Exception("It does not have enough money...");

        account.Balance -= transaction.Amount;

        transactions.Add(transaction);
        return transaction;
    }
}
