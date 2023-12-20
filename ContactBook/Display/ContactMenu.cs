using ContactBook.Models;
using ContactBook.Services;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace ContactBook.Display;

public class ContactMenu
{
    private readonly ContactService contactService;

    public ContactMenu(ContactService contactService)
    {
        this.contactService = contactService;
    }

    private void Add()
    {
        string name;

        AnsiConsole.Write(new Markup("[green]Name: [/]"));
        name = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(name))
        {
            AnsiConsole.Write(new Markup("[red]Invalid name...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Name: [/]"));
            name = Console.ReadLine().Trim();
        }

        string phone;

        AnsiConsole.Write(new Markup("[green]Phone(+998XXxxxxxxx): [/]"));
        phone = Console.ReadLine();
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid phone...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Phone(+998XXxxxxxxx): [/]"));
            phone = Console.ReadLine();
        }

        string email;

        AnsiConsole.Write(new Markup("[green]Email(example@email.com): [/]"));
        email = Console.ReadLine();
        while (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid email...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Email(example@email.com): [/]"));
            email = Console.ReadLine();
        }

        string address;

        AnsiConsole.Write(new Markup("[green]Address: [/]"));
        address = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(address))
        {
            AnsiConsole.Write(new Markup("[red]Invalid address...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Address: [/]"));
            address = Console.ReadLine().Trim();
        }

        var contact = new Contact()
        {
            Name = name,
            Phone = phone,
            Email = email,
            Address = address
        };
        contactService.Add(contact);
        AnsiConsole.Write(new Markup("[green]Successfully added...[/]\n"));
        Thread.Sleep(1500);
    }

    private void GetById()
    {
        int id;

        AnsiConsole.Write(new Markup("[green]Id: [/]"));
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Id: [/]"));
        }

        try
        {
            var contact = contactService.GetById(id);
            var table = DataTable(contact);

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
            Thread.Sleep(1500);
        }
    }

    private void Update()
    {
        int id;

        AnsiConsole.Write(new Markup("[green]Id: [/]"));
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Id: [/]"));
        }

        string name;

        AnsiConsole.Write(new Markup("[green]Name: [/]"));
        name = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(name))
        {
            AnsiConsole.Write(new Markup("[red]Invalid name...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Name: [/]"));
            name = Console.ReadLine().Trim();
        }

        string phone;

        AnsiConsole.Write(new Markup("[green]Phone(+998XXxxxxxxx): [/]"));
        phone = Console.ReadLine();
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid phone...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Phone(+998XXxxxxxxx): [/]"));
            phone = Console.ReadLine();
        }

        string email;

        AnsiConsole.Write(new Markup("[green]Email(example@email.com): [/]"));
        email = Console.ReadLine();
        while (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid email...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Email(example@email.com): [/]"));
            email = Console.ReadLine();
        }

        string address;

        AnsiConsole.Write(new Markup("[green]Address: [/]"));
        address = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(address))
        {
            AnsiConsole.Write(new Markup("[red]Invalid address...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Address: [/]"));
            address = Console.ReadLine().Trim();
        }

        var contact = new Contact()
        {
            Id = id,
            Name = name,
            Phone = phone,
            Email = email,
            Address = address
        };

        try
        {
            var existContact = contactService.Update(id, contact);
            AnsiConsole.Write(new Markup($"[green]Successfully updated...[/]\n"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void Delete()
    {
        int id;

        AnsiConsole.Write(new Markup("[green]Id: [/]"));
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Id: [/]"));
        }

        try
        {
            var isDeleted = contactService.Delete(id);
            AnsiConsole.Write(new Markup("[blue]Successfully deleted...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void GetAll()
    {
        var contacts = contactService.GetAll().ToArray();
        var table = DataTable(contacts);

        AnsiConsole.Write(table);
        AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
        Console.ReadKey();
    }

    private Table DataTable(params Contact[] contacts)
    {

        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Phone");
        table.AddColumn("Email");
        table.AddColumn("Address");

        foreach (var contact in contacts)
        {
            table.AddRow($"{contact.Id}", contact.Name, contact.Phone, contact.Email, contact.Address);
        }

        return table;
    }

    public void Display()
    {
        var selectionDisplay = new SelectionDisplay();
        var circle = true;

        while (circle)
        {
            Console.Clear();
            var selectionTable = selectionDisplay.SelectionTable("Add", "GetById", "Update", "Delete", "GetAll", "Back");
            AnsiConsole.WriteLine();

            switch (selectionTable)
            {
                case "Add":
                    Add(); 
                    break;
                case "GetById":
                    GetById(); 
                    break;
                case "Update":
                    Update(); 
                    break;
                case "Delete": 
                    Delete(); 
                    break;
                case "GetAll":
                    GetAll(); 
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
}
