namespace Anjeer.Models;

public class Customer
{
    #region Private Field
    private static int _id = 0;
    #endregion
    #region CTOR
    public Customer()
    {
        Id = ++_id;
    }
    #endregion
    #region Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    #endregion
}
