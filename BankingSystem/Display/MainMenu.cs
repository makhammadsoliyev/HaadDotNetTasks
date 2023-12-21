using BankingSystem.Services;
using Spectre.Console;

namespace BankingSystem.Display;

public class MainMenu
{
    private readonly AccountMenu accountMenu;
    private readonly TransactionMenu transactionMenu;

    private readonly AccountService accountService;
    private readonly TransactionService transactionService;

    public MainMenu()
    {
        this.accountService = new AccountService();
        this.transactionService = new TransactionService(accountService);
        this.accountMenu = new AccountMenu(accountService);
        this.transactionMenu = new TransactionMenu(transactionService);
    }
    public void Main()
    {
        var circle = true;

        while (circle)
        {
            Console.Clear();
            var table = SelectionDisplay.SelectionTable("Accounts", "Transactions", "Exit");
            AnsiConsole.WriteLine();

            switch(table)
            {
                case "Accounts":
                    accountMenu.Display();
                    break;
                case "Transactions":
                    transactionMenu.Display();
                    break;
                case "Exit":
                    circle = false;
                    break;
            }
        }
    }
}
