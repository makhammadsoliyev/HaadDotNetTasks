using ContactBook.Models;
using ContactBook.Services;
using Spectre.Console;

namespace ContactBook.Display;

public class GroupMenu
{
    private readonly GroupService groupService;

    public GroupMenu(GroupService groupService)
    {
        this.groupService = groupService;
    }

    private void Create()
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

        string description;

        AnsiConsole.Write(new Markup("[green]Description: [/]"));
        description = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(description))
        {
            AnsiConsole.Write(new Markup("[red]Invalid description...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Description: [/]"));
            description = Console.ReadLine().Trim();
        }

        var group = new Group()
        {
            Name = name,
            Description = description
        };

        groupService.Create(group);
        AnsiConsole.Write(new Markup("[blue]Successfully created...[/]"));
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
            var group = groupService.GetById(id);
            var table = DataTable(group);

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

        string description;

        AnsiConsole.Write(new Markup("[green]Description: [/]"));
        description = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(description))
        {
            AnsiConsole.Write(new Markup("[red]Invalid description...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Description: [/]"));
            description = Console.ReadLine().Trim();
        }

        var group = new Group()
        {
            Id = id,
            Name = name,
            Description = description
        };

        try
        {
            var updatedGroup = groupService.Update(id, group);
            AnsiConsole.Write(new Markup("[blue]Successfully updated...[/]"));
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
            var isDeleted = groupService.Delete(id);
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
        var groups = groupService.GetAll().ToArray();
        var table = DataTable(groups);

        AnsiConsole.Write(table);
        AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
        Console.ReadKey();
    }

    private void AddContact()
    {
        int groupId;

        AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out groupId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid groupId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        }

        int contactId;

        AnsiConsole.Write(new Markup("[green]ContactId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out contactId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid contactId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]ContactId: [/]"));
        }

        try
        {
            var group = groupService.AddContact(groupId, contactId);
            AnsiConsole.Write(new Markup("[blue]Successfully added...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void DeleteContact()
    {
        int groupId;

        AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out groupId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid groupId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        }

        int contactId;

        AnsiConsole.Write(new Markup("[green]ContactId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out contactId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid contactId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]ContactId: [/]"));
        }

        try
        {
            var group = groupService.DeleteContact(groupId, contactId);
            AnsiConsole.Write(new Markup("[blue]Successfully deleted...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void GetContacts()
    {
        int groupId;

        AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out groupId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid groupId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]GroupId: [/]"));
        }

        try
        {
            var contacts = groupService.GetContactsByGroup(groupId).ToArray();
            var table = DataTable(contacts);

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
    }

    private Table DataTable(params Group[] groups)
    {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Description");
        table.AddColumn("Contacts");

        foreach (var group in groups)
        {
            table.AddRow($"{group.Id}", group.Name, group.Description, string.Join(", ", group.Contacts.Select(c => $"{c.Id} {c.Name}")));
        }

        return table;
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
            var selectionTable = selectionDisplay.SelectionTable("Create", "GetById", "Update", "Delete", "GetAll", "AddContactToGroup", "DeleteContactFromGroup", "GetContactsByGroup", "Back");
            AnsiConsole.WriteLine();

            switch (selectionTable)
            {
                case "Create":
                    Create();
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
                case "AddContactToGroup":
                    AddContact();
                    break;
                case "DeleteContactFromGroup":
                    DeleteContact();
                    break;
                case "GetContactsByGroup":
                    GetContacts();
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
}
