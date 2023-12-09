using BankCRM.Entities;

namespace BankCRM.Interfaces;

public interface IBankService
{
    void CreateClient(Client client);
    Client GetClient(int id);
    void UpdateClient(Client client, int id);
    bool DeleteClient(int id);
    List<Client> GetAllClients();
}
