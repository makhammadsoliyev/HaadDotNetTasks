using ConsoleTables;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Menus;

public class ExpensesMenu
{
    public ExpenseService expenseService;
    public CategoryService categoryService;
    public ExpensesMenu(ExpenseService expenseService, CategoryService categoryService)
    {
        this.expenseService = expenseService;
        this.categoryService = categoryService;
    }
    private void Add()
    {
        decimal amount;

        Console.Write("Enter amount: ");
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid one.");
            Console.Write("Enter amount: ");
        }

        string description;

        Console.Write("Enter expense description: ");
        description = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.Write("Enter expense description: ");
            description = Console.ReadLine();
        }

        DateTime date = DateTime.Now;
        Category category;

        bool circle = true;
        int id;

        /*while (circle)
        {
            //categoriesMenu.GetAll();
            Console.WriteLine("Enter categoryID");
            Console.Write(">>> ");
            while(int.TryParse(Console.ReadLine(), out id) || 0 <= id)
            {
                Console.WriteLine("Enter categoryID");
                Console.Write(">>> ");
            }
            (category, List<Expense> _) = categoriesMenu.categoryService.GetById(id);
            if (category is not null)
            {
                break;
            }
            else
            {
                Console.WriteLine("Category was not found");
            }
        }*/
    }

    private void GetById()
    {

    }

    private void Update()
    {

    }

    private void Delete()
    {

    }

    private void GetAll()
    {

    }

    private void CalculateTotalExpenses()
    {

    }

    private void ExpensesByCategory()
    {

    }

    private ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Add");
        table.AddRow(2, "GetById");
        table.AddRow(3, "Update");
        table.AddRow(4, "Delete");
        table.AddRow(5, "GetAll");
        table.AddRow(6, "TotalExpenses");
        table.AddRow(7, "ExpensesByCategory");
        table.AddRow(0, "Exit");
        table.Options.EnableCount = false;

        return table;
    }

    public void Display()
    {
        ConsoleTable table = DisplayChoices();
        string choice;
        bool circle = true;

        while (circle)
        {
            table.Write(Format.MarkDown);
            Console.Write(">>> ");
            choice = Console.ReadLine();

            switch (choice)
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
                case "6":
                    CalculateTotalExpenses(); 
                    break;
                case "7":
                    ExpensesByCategory();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
