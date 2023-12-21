using BankingSystem.Interfaces;
using BankingSystem.Models;

namespace BankingSystem.Services;

public class AccountService : IAccountService
{
    private readonly List<Account> accounts;

    public AccountService()
    {
        this.accounts = new List<Account>();
    }

    public Account Create(Account account)
    {
        var existAccount = accounts.FirstOrDefault(a => a.Number.Equals(account.Number));
        if (existAccount is not null)
            throw new Exception("Account with this number already exists.");

        accounts.Add(account);
        return account;
    }

    public bool Delete(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id)
            ?? throw new Exception("Account with this id was not found...");

        return accounts.Remove(account);
    }

    public List<Account> GetAll()
        => accounts;

    public Account GetById(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id)
            ?? throw new Exception("Account with this id was not found...");

        return account;
    }

    public Account Update(int id, Account account)
    {
        var existAccount = accounts.FirstOrDefault(a => a.Id == id)
            ?? throw new Exception("Account with this id was not found...");

        existAccount.Id = id;
        existAccount.Type = account.Type;
        existAccount.Number = account.Number;
        existAccount.LastName = account.LastName;
        existAccount.FirstName = account.FirstName;

        return existAccount;
    }
}
