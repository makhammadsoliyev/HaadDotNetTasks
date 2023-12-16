using ConsoleTables;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Menus;

public class CategoriesMenu
{
    private CategoryService categoryService;
    private ExpenseService expenseService;
    public CategoriesMenu(CategoryService categoryService, ExpenseService expenseService)
    {
        this.categoryService = categoryService;
        this.expenseService = expenseService;
    }
    public void Add()
    {
        string name;
        Console.Clear();
        Console.Write("Enter expense name: ");
        name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty...");
            Console.Write("Enter expense name: ");
            name = Console.ReadLine();
        }

        string description;
        Console.Write("Enter expense description: ");
        description = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Description cannot be empty...");
            Console.Write("Enter expense description: ");
            description = Console.ReadLine();
        }

        Category category = new Category()
        {
            Name = name,
            Description = description
        };
        Category AddedCategory = categoryService.Add(category);
        ConsoleTable table = new ConsoleTable("Id", "Name", "Description");
        table.AddRow(category.Id, category.Name, category.Description);
        table.Options.EnableCount = false;
        Console.Clear();
        Console.WriteLine("Added category");
        table.Write(Format.MarkDown);
        Thread.Sleep(1500);
    }

    public void GetById()
    {
        int id;
        Console.Clear();
        Console.Write("Category Id: ");

        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Category Id: ");
        }

        Category category = categoryService.GetById(id);
        List<Expense> expenses = categoryService.GetAllExpensesByCategory(category);
        ConsoleTable categoryTable = new ConsoleTable("Id", "Name", "Description");
        ConsoleTable expensesTable = new ConsoleTable("Id", "Amount", "Description", "Date", "Category");

        Console.Clear();
        if (category is not null)
        {
            categoryTable.AddRow(category.Id, category.Name, category.Description);
            categoryTable.Options.EnableCount= false;
            Console.WriteLine("Category...");
            categoryTable.Write(Format.MarkDown);

            Thread.Sleep(1000);

            Console.WriteLine("Expenses under that category");
            foreach (Expense expense in expenses)
            {
                expensesTable.AddRow(expense.Id, expense.Amount, expense.Description, expense.Date, expense.Category);
            }
            expensesTable.Options.EnableCount = false;
            expensesTable.Write(Format.MarkDown);
            Console.WriteLine("Enter any keyboard to back menu");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Category was not found...");
            Thread.Sleep(1000);
        }
    }

    public void Update()
    {
        int id;
        Console.Clear();
        Console.Write("Category Id: ");

        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Category Id: ");
        }

        Category category = categoryService.GetById(id);
        ConsoleTable table = new ConsoleTable("Id", "Name", "Description");
        Console.Clear();
        if (category is not null)
        {
            string name;
            Console.Write("Enter expense name: ");
            name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty...");
                Console.Write("Enter expense name: ");
                name = Console.ReadLine();
            }

            string description;
            Console.Write("Enter expense description: ");
            description = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty...");
                Console.Write("Enter expense description: ");
                description = Console.ReadLine();
            }
            category.Id = id;
            category.Name = name;
            category.Description = description;
            Category updatedCategory = categoryService.Update(id, category);

            table.AddRow(updatedCategory.Id, updatedCategory.Name, updatedCategory.Description);
            table.Options.EnableCount = false;
            Console.WriteLine("Updated category...");
            table.Write(Format.MarkDown);
            Thread.Sleep(500);
        }
        else
        {
            Console.WriteLine("Category was not found...");
        }
        Thread.Sleep(1000);
    }

    public void Delete()
    {
        int id;

        Console.Clear();
        Console.Write("Category Id: ");

        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Category Id: ");
        }

        bool isDeleted = categoryService.Delete(id);
        Console.Clear();
        if (isDeleted)
            Console.WriteLine("Successfully deleted...");
        else
            Console.WriteLine("Category was not found.");
        Thread.Sleep(1000);
    }

    public void GetAll()
    {
        List<Category> categories = categoryService.GetAll();   
        ConsoleTable table = new ConsoleTable("Id", "Name", "Description");
        foreach (Category category in categories)
        {
            table.AddRow(category.Id, category.Name, category.Description);
        }
        Console.Clear();
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Please enter any keyword to go back menu...");
        Console.ReadKey();
    }

    public ConsoleTable DisplayChoices()
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
        ConsoleTable table = DisplayChoices();

        bool circle = true;
        string choice;

        while (circle)
        {
            Console.Clear();
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
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
