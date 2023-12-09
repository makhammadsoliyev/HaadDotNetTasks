using LibrarySystem.Entites;

namespace LibrarySystem.Interfaces;

public interface ILibraryService
{
    void AddBook(Book book);
    void DisplayAllBooks();
    void SearchByTitle(string title);
}
