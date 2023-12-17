namespace C_Space.Models;

public class User
{
    private static int id = 0;
    public User()
    {
        this.Id = ++id;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
