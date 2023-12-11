using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface ICustomerService
{
    void Create(Customer customer);
    void Update(int id, Customer customer);
    bool Delete (int id);
    Customer GetById (int id);
    List<Customer> GetAll();
}
