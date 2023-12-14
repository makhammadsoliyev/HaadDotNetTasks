using ConsoleTables;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Menus;

public class BookMenu
{
    public BookService bookService { get; set; }
    public BookMenu()
    {
        bookService = new BookService();
    }
    public void Add()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("The title of the book cannot be empty...");
            Console.Write("Title: ");
            title = Console.ReadLine();
        }

        Console.Write("Author: ");
        string author = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("The book must have a author...");
            Console.Write("Author: ");
            author = Console.ReadLine();
        }

        Console.Write("Genre: ");
        string genre = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(genre))
        {
            Console.WriteLine("The book must have a genre...");
            Console.Write("Genre: ");
            genre = Console.ReadLine();
        }

        int year;
        Console.Write("Publication year: ");
        while(!int.TryParse(Console.ReadLine(), out year) || year <= 0)
        {
            Console.WriteLine("Invalid year. Please enter a valid one.");
            Console.Write("Publication year: ");
        }
        Book book = new Book()
        {
            Author = author,
            BookGenre = genre,
            PublicationYear = year,
            Title = title
        };
        bookService.Add(book);
        Console.WriteLine($"{title} book successfully added...");
        Thread.Sleep(2000);
    }
    public void GetById()
    {
        int id;
        Console.Write("Book Id: ");
        while(!int.TryParse(Console.ReadLine(),out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Book Id: ");
        }
        Book book = bookService.GetById(id);
        if (book is not null)
        {
            ConsoleTable table = new ConsoleTable("Id", "Title", "Author", "Genre", "Publication year", "Availability");
            table.AddRow(book.Id, book.Title, book.Author, book.BookGenre, book.PublicationYear, book.Availability);
            table.Options.EnableCount = false;
            table.Write();
        } 
        else
        {
            Console.WriteLine("Book was not found...");
        }
        Thread.Sleep(2000);
        
    }
    public void Update()
    {
        int id;
        Console.Write("Book Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one.");
            Console.Write("Book Id: ");
        }
        Book book = bookService.GetById(id);
        if (book is not null)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("The title of the book cannot be empty...");
                Console.Write("Title: ");
                title = Console.ReadLine();
            }

            Console.Write("Author: ");
            string author = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("The book must have a author...");
                Console.Write("Author: ");
                author = Console.ReadLine();
            }

            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("The book must have a genre...");
                Console.Write("Genre: ");
                genre = Console.ReadLine();
            }

            int year;
            Console.Write("Publication year: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
            {
                Console.WriteLine("Invalid year. Please enter a valid one.");
                Console.Write("Publication year: ");
            }
            book.Id = id;
            book.Title = title;
            book.Author = author;
            book.BookGenre = genre;
            book.Availability = true;
            book.PublicationYear = year;
            Console.WriteLine("Book successfully updated...");
        }
        else
        {
            Console.WriteLine("Book was not found...");
        }
        Thread.Sleep(2000);
    }
    public void Delete()
    {
        int id;
        Console.Write("Book Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id. Please enter a valid one...");
            Console.Write("Book Id: ");
        }
        bool isDeleted = bookService.Delete(id);
        if (isDeleted)
            Console.WriteLine("Book successfully deleted...");
        else
            Console.WriteLine("Book was not found...");
        Thread.Sleep(2000);
    }
    public void GetAll()
    {
        List<Book> books = bookService.GetAll();
        ConsoleTable table = new ConsoleTable("Id", "Title", "Author", "Genre", "Publication year", "Availability");
        foreach (Book book in books)
        {
            table.AddRow(book.Id, book.Title, book.Author, book.BookGenre, book.PublicationYear, book.Availability);
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Thread.Sleep(4000);
    }
    public ConsoleTable DisplayMenu()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Add");
        table.AddRow(2, "GetById");
        table.AddRow(3, "Update");
        table.AddRow(4, "Delete");
        table.AddRow(5, "GetAll");
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
                    GetAll(); 
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }

    }
}
