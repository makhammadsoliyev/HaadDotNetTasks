using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class CustomerService : ICustomerService
{
    #region Private Field
    private List<Customer> customers;
    #endregion
    #region CTOR
    public CustomerService()
    {
        customers = new List<Customer>();
    }
    #endregion
    #region Methods
    public void Create(Customer customer)
    {
        customers.Add(customer);
    }

    public bool Delete(int id)
        => customers.Remove(GetById(id));

    public List<Customer> GetAll()
        => customers;

    public Customer GetById(int id)
        => customers.FirstOrDefault(customer => customer.Id.Equals(id));

    public void Update(int id, Customer customer)
    {
        Customer customerToUpdate = GetById(id);
        customerToUpdate.Id = id;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.DateOfBirth = customer.DateOfBirth;
        customerToUpdate.PhoneNumber = customer.PhoneNumber;
    }
    #endregion
}
