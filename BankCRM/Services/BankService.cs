using BankCRM.Entities;
using BankCRM.Interfaces;

namespace BankCRM.BankService;

public class BankService : IBankService
{
    private List<Client> clients;

    public BankService()
    {
        clients = new List<Client>();
    }
    public void CreateClient(Client client)
    {
        clients.Add(client);
        Console.WriteLine("Successfully added...");
    }

    public bool DeleteClient(int id)
    {
        return clients.Remove(GetClient(id));
    }

    public List<Client> GetAllClients()
    {
        return clients;
    }

    public Client GetClient(int id)
    {
        return clients.FirstOrDefault(c => c.Id == id);
    }

    public void UpdateClient(Client client, int id)
    {
        int index = clients.FindIndex(c  => c.Id == id);
        if (index == -1)
        {
            Console.WriteLine("Client was not found...");
        }
        else
        {
            client.Id = id;
            client.RegisteredTime = clients[index].RegisteredTime;
            clients[index] = client;
            Console.WriteLine("Successfully updated...");
        }
    }
}
