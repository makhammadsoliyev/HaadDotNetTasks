using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces;

public interface IMemberService
{
    public void Add(Member member);
    public Member GetById(int id);
    public void Update(int id, Member member);
    public bool Delete(int id);
    public void BorrowBook(int MemberId, Book book);
    public void ReturnBook(int MemberId, Book book);
    public List<Book> GetAllBorrowedBooks(int MemberId);
    public List<Member> GetAll();
}
