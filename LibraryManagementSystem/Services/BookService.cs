using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services;

public class BookService : IBookService
{
    private List<Book> books;
    public BookService()
    {
        books = new List<Book>();
    }
    public void Add(Book book)
    {
        books.Add(book);
    }

    public bool Delete(int id)
        => books.Remove(GetById(id));

    public List<Book> GetAll()
        => books;

    public Book GetById(int id)
        => books.FirstOrDefault(book => book.Id == id);

    public void Update(int id, Book book)
    {
        Book bookToUpdate = GetById(id);
        bookToUpdate.Id = id;
        bookToUpdate.Title = book.Title;
        bookToUpdate.Author = book.Author;
        bookToUpdate.BookGenre = book.BookGenre;
        bookToUpdate.Availability = book.Availability;
        bookToUpdate.PublicationYear = book.PublicationYear;
    }
}
