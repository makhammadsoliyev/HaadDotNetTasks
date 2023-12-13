namespace LibraryManagementSystem.Models;

public partial class Book
{
    private int _id = 0;
    public Book()
    {
        Id = _id++;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public Genre BookGenre { get; set; }
    public int PublicationYear { get; set; }
    public bool Availability { get; set; } = true;
}
