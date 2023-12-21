using BankingSystem.Models;
using BankingSystem.Services;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace BankingSystem.Display;

public class AccountMenu
{
    private readonly AccountService accountService;

    public AccountMenu(AccountService accountService)
    {
        this.accountService = accountService;
    }

    private void Create()
    {
        string firstName;

        AnsiConsole.Write(new Markup("[green]FirstName: [/]"));
        firstName = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(firstName))
        {
            AnsiConsole.Write(new Markup("[red]Invalid firstName...[/]\n"));
            AnsiConsole.Write(new Markup("[green]FirstName: [/]"));
            firstName = Console.ReadLine().Trim();
        }

        string lastName;

        AnsiConsole.Write(new Markup("[green]LastName: [/]"));
        lastName = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(lastName))
        {
            AnsiConsole.Write(new Markup("[red]Invalid lastName...[/]\n"));
            AnsiConsole.Write(new Markup("[green]LastName: [/]"));
            lastName = Console.ReadLine().Trim();
        }

        int accountType;

        AnsiConsole.Write(new Markup("[green]AccountType(1. Saving. 2. Checking): [/]"));
        while(!int.TryParse(Console.ReadLine(), out accountType) || accountType != 1 && accountType != 2)
        {
            AnsiConsole.Write(new Markup("[red]Invalid AccountType...[/]\n"));
            AnsiConsole.Write(new Markup("[green]AccountType(1. Saving. 2. Checking): [/]"));
        }

        decimal balance;

        AnsiConsole.Write(new Markup("[green]Balance: [/]"));
        while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
        {
            AnsiConsole.Write(new Markup("[red]Invalid Balance...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Balance: [/]"));
        }

        string number;

        AnsiConsole.Write(new Markup("[green]Number(8-12 numbers): [/]"));
        number = Console.ReadLine();
        while (!Regex.IsMatch(number, @"^\d{8,20}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid Number...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Number(8-12 numbers): [/]"));
            number = Console.ReadLine();
        }

        var account = new Account()
        {
            Balance = balance,
            FirstName = firstName,
            LastName = lastName,
            Number = number,
            Type = (AccountType)accountType
        };

        try
        {
            var addedAccount = accountService.Create(account);
            AnsiConsole.Write(new Markup("[blue]Successfully created...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
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
            var account = accountService.GetById(id);
            var table = DataTable(account);

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            //AnsiConsole.WriteException(ex, format: ExceptionFormats.ShortenEverything);
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

        string firstName;

        AnsiConsole.Write(new Markup("[green]FirstName: [/]"));
        firstName = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(firstName))
        {
            AnsiConsole.Write(new Markup("[red]Invalid firstName...[/]\n"));
            AnsiConsole.Write(new Markup("[green]FirstName: [/]"));
            firstName = Console.ReadLine().Trim();
        }

        string lastName;

        AnsiConsole.Write(new Markup("[green]LastName: [/]"));
        lastName = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(lastName))
        {
            AnsiConsole.Write(new Markup("[red]Invalid lastName...[/]\n"));
            AnsiConsole.Write(new Markup("[green]LastName: [/]"));
            lastName = Console.ReadLine().Trim();
        }

        int accountType;

        AnsiConsole.Write(new Markup("[green]AccountType(1. Saving. 2. Checking): [/]"));
        while (!int.TryParse(Console.ReadLine(), out accountType) || accountType != 1 && accountType != 2)
        {
            AnsiConsole.Write(new Markup("[red]Invalid AccountType...[/]\n"));
            AnsiConsole.Write(new Markup("[green]AccountType(1. Saving. 2. Checking): [/]"));
        }

        string number;

        AnsiConsole.Write(new Markup("[green]Number(8-12 numbers): [/]"));
        number = Console.ReadLine();
        while (!Regex.IsMatch(number, @"^\d{8,20}$"))
        {
            AnsiConsole.Write(new Markup("[red]Invalid Number...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Number(8-12 numbers): [/]"));
            number = Console.ReadLine();
        }

        var account = new Account()
        {
            FirstName = firstName,
            LastName = lastName,
            Number = number,
            Id = id,
            Type = (AccountType)accountType
        };

        try
        {
            var updatedAccount = accountService.Update(id, account);
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
            var isDeleted = accountService.Delete(id);
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
        var accounts = accountService.GetAll().ToArray();
        var table = DataTable(accounts);

        AnsiConsole.Write(table);
        AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
        Console.ReadKey();
    }

    private Table DataTable(params Account[] accounts)
    {

        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("FirstName");
        table.AddColumn("LastName");
        table.AddColumn("Type");
        table.AddColumn("Balance");
        table.AddColumn("Number");

        foreach (var account in accounts)
        {
            table.AddRow(account.Id.ToString(), account.FirstName, account.LastName, account.Type.ToString(), $"{account.Balance:C4}", account.Number);
        }

        return table;
    }

    public void Display()
    {
        var circle = true;

        while (circle)
        {
            Console.Clear();
            var table = SelectionDisplay.SelectionTable("Create", "GetById", "Update", "Delete", "GetAll", "Back");
            AnsiConsole.WriteLine();

            switch (table)
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
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
}
