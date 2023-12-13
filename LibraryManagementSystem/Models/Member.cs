namespace LibraryManagementSystem.Models;

public class Member
{
    private int _id = 0;
    public Member()
    {
        Id = _id++;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public List<Book> BorrowedBooks { get; set; }
}
