using BankingSystem.Models;

namespace BankingSystem.Interfaces;

internal interface IAccountService
{
    Account Create(Account account);
    Account GetById(int id);
    Account Update(int id, Account account);
    bool Delete(int id);
    List<Account> GetAll();
}
