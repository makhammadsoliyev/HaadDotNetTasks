using BankingSystem.Models;
using BankingSystem.Services;
using Spectre.Console;

namespace BankingSystem.Display;

public class TransactionMenu
{
    private readonly TransactionService transactionService;

    public TransactionMenu(TransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    private void DepositFunds()
    {
        int receiverAccountId;

        AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out receiverAccountId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        }

        decimal amount;

        AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
        {
            AnsiConsole.Write(new Markup("[red]Invalid Amount...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        }

        var transaction = new Transaction()
        {
            Amount = amount,
            Type = TransactionType.Deposit,
            ReceiverAccountId = receiverAccountId
        };

        try
        {
            var createdTransaction = transactionService.DepositFunds(transaction);
            AnsiConsole.Write(new Markup("[blue]Successfully deposited...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void WithdrawFunds()
    {
        int senderAccountId;

        AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out senderAccountId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        }

        decimal amount;

        AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
        {
            AnsiConsole.Write(new Markup("[red]Invalid Amount...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        }

        var transaction = new Transaction()
        {
            Amount = amount,
            Type = TransactionType.Withdraw,
            SenderAccountId = senderAccountId
        };

        try
        {
            var createdTransaction = transactionService.WithdrawFunds(transaction);
            AnsiConsole.Write(new Markup("[blue]Successfully withdrew...[/]"));
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[red]{ex.Message}[/]\n"));
        }
        Thread.Sleep(1500);
    }

    private void PerformFundTransfer()
    {
        int senderAccountId;

        AnsiConsole.Write(new Markup("[green]SenderAccountId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out senderAccountId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]SenderAccountId: [/]"));
        }

        int receiverAccountId;

        AnsiConsole.Write(new Markup("[green]ReceiverAccountId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out receiverAccountId))
        {
            AnsiConsole.Write(new Markup("[red]Invalid id...[/]\n"));
            AnsiConsole.Write(new Markup("[green]ReceiverAccountId: [/]"));
        }

        decimal amount;

        AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
        {
            AnsiConsole.Write(new Markup("[red]Invalid Amount...[/]\n"));
            AnsiConsole.Write(new Markup("[green]Amount: [/]"));
        }

        var transaction = new Transaction()
        {
            Amount = amount,
            Type = TransactionType.Transfer,
            SenderAccountId = senderAccountId,
            ReceiverAccountId = receiverAccountId
        };

        try
        {
            var createdTransaction = transactionService.PerformFundTransfer(transaction);
            AnsiConsole.Write(new Markup("[blue]Successfully transferred...[/]"));
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
            var transaction = transactionService.GetById(id);
            var table = DataTable(transaction);

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

    private void GetTransactionHistory()
    {
        int id;

        AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            AnsiConsole.Write(new Markup("[red]Invalid accountId...[/]\n"));
            AnsiConsole.Write(new Markup("[green]AccountId: [/]"));
        }

        var transactions = transactionService.GetTransactionHistory(id).ToArray();
        var table = DataTable(transactions);

        AnsiConsole.Write(table);
        AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
        Console.ReadKey();
    }

    private void GetAll()
    {
        var transactions = transactionService.GetAll().ToArray();
        var table = DataTable(transactions);

        AnsiConsole.Write(table);
        AnsiConsole.Write(new Markup($"[blue]Press any keyboard to continue...[/]\n"));
        Console.ReadKey();
    }

    private Table DataTable(params Transaction[] transactions)
    {

        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("SenderAccountId");
        table.AddColumn("ReceiverAccountId");
        table.AddColumn("Type");
        table.AddColumn("Amount");

        foreach (var transaction in transactions)
        {
            table.AddRow(transaction.Id.ToString(), transaction.SenderAccountId.ToString(), transaction.ReceiverAccountId.ToString(), transaction.Type.ToString(), $"{transaction.Amount:C4}");
        }

        return table;
    }

    public void Display()
    {
        var circle = true;

        while (circle)
        {
            Console.Clear();
            var table = SelectionDisplay.SelectionTable("DepositFunds", "WithdrawFunds", "PerformFundTransfer", "GetById", "GetTransactionHistory", "GetAll", "Back");
            AnsiConsole.WriteLine();

            switch (table)
            {
                case "DepositFunds":
                    DepositFunds();
                    break;
                case "WithdrawFunds":
                    WithdrawFunds();
                    break;
                case "PerformFundTransfer":
                    PerformFundTransfer();
                    break;
                case "GetById":
                    GetById();
                    break;
                case "GetTransactionHistory":
                    GetTransactionHistory();
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