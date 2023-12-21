using BankingSystem.Models;

namespace BankingSystem.Interfaces;

public interface ITransactionService
{
    Transaction DepositFunds(Transaction transaction);
    Transaction WithdrawFunds(Transaction transaction);
    Transaction PerformFundTransfer(Transaction transaction);
    List<Transaction> GetTransactionHistory(int accountId);
    Transaction GetById(int id);
    List<Transaction> GetAll();
}
