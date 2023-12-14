namespace LibraryManagementSystem.Models;

public partial class Book
{
    private static int _id = 0;
    public Book()
    {
        Id = ++_id;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string BookGenre { get; set; }
    public int PublicationYear { get; set; }
    public bool Availability { get; set; } = true;
}
