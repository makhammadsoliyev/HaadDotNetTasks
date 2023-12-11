namespace Anjeer.Models;

public class Employee
{
    #region Private Field
    private static int _id = 0;
    #endregion
    #region CTOR
    public Employee()
    {
        Id = ++_id;
    }
    #endregion
    #region Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Position Position { get; set; }
    public string PassportNumber { get; set; }
    #endregion
}
