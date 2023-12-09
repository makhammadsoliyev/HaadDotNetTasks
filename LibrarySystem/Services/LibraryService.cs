using LibrarySystem.Entites;
using LibrarySystem.Interfaces;

namespace LibrarySystem.Services;

public class LibraryService : ILibraryService, ISortableService
{
    private List<Book> books;
    public LibraryService()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Successfully added...");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("All books.");
        foreach (var book in books)
        {
            Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Author: {book.Author}, PublicationYear: {book.PublicationYear}");
        }
    }

    public void SearchByTitle(string title)
    {
        Book book = books.FirstOrDefault(book => book.Title == title);
        if (book == null)
        {
            Console.WriteLine("Book was not found...");
        }
        else
        {
            Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Author: {book.Author}, PublicationYear: {book.PublicationYear}");
        }

    }

    public void Sort(List<Book> books)
    {
        books = books.OrderBy(book => book.PublicationYear).ToList();
        Console.WriteLine("Successfully sorted...");
    }

    public List<Book> Books { get => books; }
}
