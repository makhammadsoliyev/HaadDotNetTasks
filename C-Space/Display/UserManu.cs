using C_Space.Models;
using C_Space.Services;
using ConsoleTables;
using System.Numerics;
using System.Text.RegularExpressions;

namespace C_Space.Display;

public class UserManu
{
    private readonly UserService userService;

    public UserManu(UserService userService)
    {
        this.userService = userService;
    }

    public void Create()
    {
        User user;

        Console.Write("FirstName: ");
        string firstName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(firstName))
        {
            Console.WriteLine("FirstName cannot be empty");
            Console.Write("FirstName: ");
            firstName = Console.ReadLine();
        }

        Console.Write("LastName: ");
        string lastName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("LastName cannot be empty");
            Console.Write("LastName: ");
            lastName = Console.ReadLine();
        }

        Console.Write("Phone(+998XXxxxxxxx): ");
        string phone = Console.ReadLine();
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            Console.WriteLine("Invalid phone");
            Console.Write("Phone(+998XXxxxxxxx): ");
            phone = Console.ReadLine();
        }

        Console.Write("Email(example@gmail.com): ");
        string email = Console.ReadLine();
        while (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            Console.WriteLine("Invalid email");
            Console.Write("Email(example@gmail.com): ");
            email = Console.ReadLine();
        }

        user = new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone
        };

        try
        {
            userService.Create(user);
            Console.WriteLine("Successfully added...");
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void Update()
    {
        User user;

        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        Console.Write("FirstName: ");
        string firstName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(firstName))
        {
            Console.WriteLine("FirstName cannot be empty");
            Console.Write("FirstName: ");
            firstName = Console.ReadLine();
        }

        Console.Write("LastName: ");
        string lastName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("LastName cannot be empty");
            Console.Write("LastName: ");
            lastName = Console.ReadLine();
        }

        Console.Write("Phone(+998XXxxxxxxx): ");
        string phone = Console.ReadLine();
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            Console.WriteLine("Invalid phone");
            Console.Write("Phone(+998XXxxxxxxx): ");
            phone = Console.ReadLine();
        }

        Console.Write("Email(example@email.com): ");
        string email = Console.ReadLine();
        while (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            Console.WriteLine("Invalid email");
            Console.Write("Email(example@email.com): ");
            email = Console.ReadLine();
        }

        user = new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone
        };

        
        try
        {
            userService.Update(id, user);
            Console.WriteLine("Successfully updated...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void Delete()
    {
        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        try
        {
            userService.Delete(id);
            Console.WriteLine("Successfully deleted...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void GetById()
    {
        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        try
        {
            User user = userService.GetById(id);

            ConsoleTable table = new ConsoleTable("Id", "FirstName", "LastName", "Phone", "Email");
            table.AddRow(user.Id, user.FirstName, user.LastName, user.Phone, user.Email);
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Console.WriteLine("Press any keyword to continue");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Thread.Sleep(1500);
        }
    }

    public void GetAll()
    {
        List<User> users = userService.GetAll();

        ConsoleTable table = new ConsoleTable("Id", "FirstName", "LastName", "Phone", "Email");
        foreach (User user in users)
        {
            table.AddRow(user.Id, user.FirstName, user.LastName, user.Phone, user.Email);
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyword to continue");
        Console.ReadKey();
    }

    public static ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow("1", "Create");
        table.AddRow("2", "Update");
        table.AddRow("3", "GetById");
        table.AddRow("4", "GetAll");
        table.AddRow("5", "Delete");
        table.AddRow("0", "Back");
        table.Options.EnableCount = false;

        return table;
    }

    public void Display()
    {
        bool circle = true;
        ConsoleTable table = DisplayChoices();
        string option;

        while (circle)
        {
            Console.Clear();
            table.Write(Format.MarkDown);
            Console.Write(">>> ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Create();
                    break;
                case "2":
                    Update();
                    break;
                case "3":
                    GetById();
                    break;
                case "4":
                    GetAll(); 
                    break;
                case "5":
                    Delete(); 
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
