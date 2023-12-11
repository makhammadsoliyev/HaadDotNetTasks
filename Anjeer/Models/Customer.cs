namespace Anjeer.Models;

public class Customer
{
    private int _id = 0;
    public Customer()
    {
        Id = ++_id;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
