namespace ContactBook.Models;

public class Contact
{
    private static int id = 0;

    public Contact()
    {
        this.Id = ++id;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
