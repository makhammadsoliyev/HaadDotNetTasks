using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services;

public class MemberService : IMemberService
{
    private List<Member> members;
    private BookService bookService;
    public MemberService(BookService bookService)
    {
        members = new List<Member>();
        this.bookService = bookService;
    }

    public void Add(Member member)
    {
        members.Add(member);
    }

    public void BorrowBook(int MemberId, Book book)
    {
        Member member = GetById(MemberId);
        if (member is null)
        {
            throw new Exception("Member is not found...");
        }
        if (book is null)
        {
            throw new Exception("Book is not found");
        }
        member.BorrowedBooks.Add(book);

        Book borrowedBook = bookService.GetById(book.Id);
        borrowedBook.Availability = false;
    }

    public bool Delete(int id)
        => members.Remove(GetById(id));

    public List<Member> GetAll()
        => members;

    public List<Book> GetAllBorrowedBooks(int MemberId)
    {
        Member member = GetById(MemberId);
        return member.BorrowedBooks;
    }
    public Member GetById(int id)
        => members.FirstOrDefault(member  => member.Id == id);

    public void ReturnBook(int MemberId, Book book)
    {
        Member member = GetById(MemberId);
        if (member is null)
        {
            throw new Exception("Member is not found...");
        }
        if (book is null)
        {
            throw new Exception("Book is not found");
        }
        member.BorrowedBooks.Remove(book);

        Book borrowedBook = bookService.GetById(book.Id);
        borrowedBook.Availability = true;
    }

    public void Update(int id, Member member)
    {
        Member memberToUpdate = GetById(id);
        memberToUpdate.Id = id;
        memberToUpdate.Name = member.Name;
        memberToUpdate.Phone = member.Phone;
        memberToUpdate.Email = member.Email;
        memberToUpdate.Address = member.Address;
        memberToUpdate.BorrowedBooks = member.BorrowedBooks;
    }
}
