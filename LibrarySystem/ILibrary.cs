namespace LibrarySystem;

public interface ILibrary
{
    void AddBook(Book book);
    void DisplayAllBooks();
    void SearchByTitle(string title);
}
