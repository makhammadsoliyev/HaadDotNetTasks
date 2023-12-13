using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces;

public interface IBookService
{
    public void Add(Book book);
    public bool Delete(int id);
    public void Update(int id, Book book);
    public Book GetById(int id);
}
