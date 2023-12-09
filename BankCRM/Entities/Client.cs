namespace BankCRM.Entities;

public class Client
{
    private static int id = 0;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegisteredTime { get; set; }
    public Client()
    {
        Id = ++id;
        RegisteredTime = DateTime.Now;
    }
}
