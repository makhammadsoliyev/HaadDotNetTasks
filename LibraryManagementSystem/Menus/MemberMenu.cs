using ConsoleTables;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.Menus;

public class MemberMenu
{
    public MemberService memberService { get; set; }
    private BookService bookService;
    public MemberMenu(BookService bookService)
    {
        this.bookService = bookService;
        memberService = new MemberService(this.bookService);
    }
    public void Add()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("The name of the member cannot be empty...");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        Console.Write("Phone(+998XXxxxxxxx): ");
        string phoneNumber = Console.ReadLine();
        while (!Regex.IsMatch(phoneNumber, @"^\+998\d{9}$"))
        {
            Console.WriteLine("Invalid number. Please enter a valid one.");
            Console.Write("Phone(+998XXxxxxxxx): ");
            phoneNumber = Console.ReadLine();
        }

        Console.Write("Email(example@example.com): ");
        string email = Console.ReadLine();
        while (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
        {
            Console.WriteLine("Invalid email. Please enter a valid one.");
            Console.Write("Email(example@example.com): ");
            email = Console.ReadLine();
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(address))
        {
            Console.WriteLine("The address of the member cannot be empty...");
            Console.Write("Address: ");
            address = Console.ReadLine();
        }
        Member member = new Member()
        {
            Name = name,
            Address = address,
            Email = email,
            Phone = phoneNumber
        };
        memberService.Add(member);
        Console.WriteLine($"{name} successfully added...");
        Thread.Sleep(2000);
    }
    public void GetById()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        Member member = memberService.GetById(id);
        if (member is not null)
        {
            ConsoleTable table = new ConsoleTable("Id", "Name", "Phone", "Email", "Address", "BorrowedBook Number");
            table.AddRow(member.Id, member.Name, member.Phone, member.Email, member.Address, member.BorrowedBooks.Count);
            table.Options.EnableCount = false;
            table.Write();
        }
        else
        {
            Console.WriteLine("Member was not found...");
        }
        Thread.Sleep(2000);
    }
    public void Update()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        Member member = memberService.GetById(id);
        if (member is  not null)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("The name of the member cannot be empty...");
                Console.Write("Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Phone(+998XXxxxxxxx): ");
            string phoneNumber = Console.ReadLine();
            while (!Regex.IsMatch(phoneNumber, @"^\+998\d{9}$"))
            {
                Console.WriteLine("Invalid number. Please enter a valid one.");
                Console.Write("Phone(+998XXxxxxxxx): ");
                phoneNumber = Console.ReadLine();
            }

            Console.Write("Email(example@example.com): ");
            string email = Console.ReadLine();
            while (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                Console.WriteLine("Invalid email. Please enter a valid one.");
                Console.Write("Email(example@example.com): ");
                email = Console.ReadLine();
            }

            Console.Write("Address: ");
            string address = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("The address of the member cannot be empty...");
                Console.Write("Address: ");
                address = Console.ReadLine();
            }
            member.Id = id;
            member.Name = name;
            member.Email = email;
            member.Address = address;
            member.Phone = phoneNumber;
        }
        else
        {
            Console.WriteLine("Member was not found...");
        }
        Thread.Sleep(2000);
    }
    public void Delete()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        bool isDeleted = memberService.Delete(id);
        if (isDeleted)
            Console.WriteLine("Member successfully deleted...");
        else
            Console.WriteLine("Member was not found...");
        Thread.Sleep(2000);
    }
    public void BorrowBook()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        Member member = memberService.GetById(id);
        if (member is not null)
        {
            int bookId;
            Console.Write("Book Id: ");
            while (!int.TryParse(Console.ReadLine(), out bookId) || bookId <= 0)
            {
                Console.WriteLine("Invalid id. Please enter a valid one...");
                Console.Write("Book Id: ");
            }
            Book book = bookService.GetById(bookId);
            if (book is not null)
            {
                if (book.Availability)
                {
                    memberService.BorrowBook(id, book);
                    Console.WriteLine("Book successfully borrowed...");
                }
                else
                {
                    Console.WriteLine("Sorry. This book has already borrowed...");
                }
            }
            else
            {
                Console.WriteLine("Book was not found...");
            }

        }
        else
        {
            Console.WriteLine("Member was not found...");
        }
        Thread.Sleep(2000);
    }
    public void ReturnBook()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        Member member = memberService.GetById(id);
        if (member is not null)
        {
            int bookId;
            Console.Write("Book Id: ");
            while (!int.TryParse(Console.ReadLine(), out bookId) || bookId <= 0)
            {
                Console.WriteLine("Invalid id. Please enter a valid one...");
                Console.Write("Book Id: ");
            }
            Book book = member.BorrowedBooks.FirstOrDefault(book => book.Id == bookId);
            if (book is not null)
            {
                memberService.ReturnBook(id, book);
                Console.WriteLine("Book successfully borrowed...");
            }
            else
            {
                Console.WriteLine("This was not borrowed here...");
            }
        }
        else
        {
            Console.WriteLine("Book was not found...");
        }
        Thread.Sleep(2000);
    }
    public void GetAllBorrowedBooks()
    {
        int id;
        Console.Write("Member Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Member Id: ");
        }
        Member member = memberService.GetById(id);
        if (member is not null)
        {
            List<Book> books = member.BorrowedBooks;
            ConsoleTable table = new ConsoleTable("Id", "Title", "Author", "Genre", "Publication year", "Availability");
            foreach (Book book in books)
            {
                table.AddRow(book.Id, book.Title, book.Author, book.BookGenre, book.PublicationYear, book.Availability);
            }
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Thread.Sleep(4000);
        }
        else
        {
            Console.WriteLine("Member was not found...");
            Thread.Sleep(2000);
        }
    }
    public void GetAll()
    {
        List<Member> members = memberService.GetAll();
        ConsoleTable table = new ConsoleTable("Id", "Name", "Phone", "Email", "Address", "BorrowedBook Number");
        foreach (Member member in members)
        {
            table.AddRow(member.Id, member.Name, member.Phone, member.Email, member.Address, member.BorrowedBooks.Count);
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Thread.Sleep(6000);
    }
    public ConsoleTable DisplayMenu()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Register");
        table.AddRow(2, "GetById");
        table.AddRow(3, "Update");
        table.AddRow(4, "Delete");
        table.AddRow(5, "BorrowBook");
        table.AddRow(6, "ReturnBook");
        table.AddRow(7, "GetAllBorrowedBooks");
        table.AddRow(8, "GetAll");
        table.AddRow(0, "Go Back");
        table.Options.EnableCount = false;

        return table;
    }
    public void Display()
    {
        ConsoleTable table = DisplayMenu();
        bool circle = true;
        while (circle)
        {
            Console.Clear();
            table.Write(Format.MarkDown);
            Console.Write(">>> ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    GetById(); 
                    break;
                case "3":
                    Update(); 
                    break;
                case "4":
                    Delete(); 
                    break;
                case "5":
                    BorrowBook(); 
                    break;
                case "6":
                    ReturnBook();
                    break;
                case "7":
                    GetAllBorrowedBooks(); 
                    break;
                case "8":
                    GetAll();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
