namespace ContactBook.Models;

public class Group
{
    private static int id = 0;

    public Group()
    {
        this.Id = ++id;
        this.Contacts = new List<Contact>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Contact> Contacts { get; set; }
}
