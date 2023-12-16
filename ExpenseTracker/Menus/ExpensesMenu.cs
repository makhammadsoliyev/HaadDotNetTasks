using ConsoleTables;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Menus;

public class ExpensesMenu
{
    private ExpenseService expenseService;
    private CategoryService categoryService;
    private CategoriesMenu categoriesMenu;

    public ExpensesMenu(ExpenseService expenseService, CategoryService categoryService, CategoriesMenu categoriesMenu)
    {
        this.expenseService = expenseService;
        this.categoryService = categoryService;
        this.categoriesMenu = categoriesMenu;
    }
    public void Add()
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
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow(1, "To use available categories");
        table.AddRow(2, "Create a new category");
        table.Options.EnableCount = false;

        Category category;
        bool circle = true;
        while (circle)
        {
            string option;
            Console.WriteLine("Now you need to enter expense category. Here are options.");
            table.Write(Format.MarkDown);
            Console.Write(">>> ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Category table
                    while (true)
                    {
                        int id;
                        Console.WriteLine("Here are available categories");
                        categoriesMenu.GetAll();
                        Console.WriteLine("0, Go back");
                        Console.Write("Category Id: ");

                        
                        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
                        {
                            Console.WriteLine("Invalid Id. Please enter a valid one.");
                            Console.Write("Category Id: ");
                        }
                        if (id == 0) break;
                        category = categoryService.GetById(id);
                        if (category is not null)
                        {
                            Expense expense = new Expense()
                            {
                                Amount = amount,
                                Description = description,
                                Date = date,
                                Category = category
                            };
                            Expense addExpense = expenseService.Add(expense);
                            ConsoleTable categoryTable = new ConsoleTable("ID", "Amount", "Description", "Date", "Category");
                            categoryTable.AddRow(addExpense.Id, $"{addExpense.Amount:C4}", addExpense.Description, addExpense.Date, addExpense.Category.Name);
                            categoryTable.Options.EnableCount = false;
                            Console.Clear();
                            Console.WriteLine("Added expense");
                            categoryTable.Write(Format.MarkDown);
                            Thread.Sleep(1500);
                            circle = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Category was not found..");
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                    break;
                case "2":
                    categoriesMenu.Add();
                    break; 
            }
        }
    }

    public void GetById()
    {
        int id;
        Console.Clear();
        Console.Write("Expense Id: ");

        while(!int.TryParse(Console.ReadLine(), out id) || id <=0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Expense Id: ");
        }
        Expense expense = expenseService.GetById(id);
        if (expense is not null)
        {
            ConsoleTable table = new ConsoleTable("ID", "Amount", "Description", "Date", "Category");
            table.AddRow(expense.Id, $"{expense.Amount:C4}", expense.Description, expense.Date, expense.Category.Name);
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Thread.Sleep(1500);
        }
        else
        {
            Console.WriteLine("Expense was not found...");
            Thread.Sleep(1000);
        }
    }

    public void Update()
    {
        int id;
        Console.Clear();
        Console.Write("Expense Id: ");

        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Expense Id: ");
        }
        Expense expense = expenseService.GetById(id);

        if (expense is not null)
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
            ConsoleTable table = new ConsoleTable("N", "Options");
            table.AddRow(1, "To use available categories");
            table.AddRow(2, "Create a new category");
            table.Options.EnableCount = false;

            Category category;
            bool circle = true;
            while (circle)
            {
                string option;
                Console.WriteLine("Now you need to enter expense category. Here are options.");
                table.Write(Format.MarkDown);
                Console.Write(">>> ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Category table
                        while (true)
                        {
                            int categoryId;
                            Console.WriteLine("Here are available categories");
                            categoriesMenu.GetAll();
                            Console.WriteLine("0, Go back");
                            Console.Write("Category Id: ");

                            while (!int.TryParse(Console.ReadLine(), out categoryId) || categoryId < 0)
                            {
                                Console.WriteLine("Invalid Id. Please enter a valid one.");
                                Console.Write("Category Id: ");
                            }

                            if (categoryId == 0) break;
                            category = categoryService.GetById(categoryId);
                            if (category is not null)
                            {
                                expense.Id = id;
                                expense.Category = category;
                                expense.Amount = amount;
                                expense.Description = description;
                                expense.Category = category;
                                Expense updatedExpense = expenseService.Update(id, expense);
                                ConsoleTable categoryTable = new ConsoleTable("ID", "Amount", "Description", "Date", "Category");
                                categoryTable.AddRow(updatedExpense.Id, $"{updatedExpense.Amount:C4}", updatedExpense.Description, updatedExpense.Date, updatedExpense.Category.Name);
                                categoryTable.Options.EnableCount = false;
                                Console.Clear();
                                Console.WriteLine("Updated expense");
                                categoryTable.Write(Format.MarkDown);
                                Thread.Sleep(2000);
                                circle = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Category was not found..");
                                Thread.Sleep(1000);
                                break;
                            }
                        }
                        break;
                    case "2":
                        categoriesMenu.Add();
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Expense was not found");
            Thread.Sleep(1000);
        }
    }

    public void Delete()
    {
        int id;
        Console.Clear();
        Console.Write("Expense Id: ");

        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Console.Write("Expense Id: ");
        }
        bool isDeleted = expenseService.Delete(id);
        if (isDeleted)
        {
            Console.WriteLine("Successfully deleted...");
        }
        else
        {
            Console.WriteLine("Expense was not found..");
        }
        Thread.Sleep(1000);
    }

    public void GetAll()
    {
        List<Expense> expenses = expenseService.GetAll();
        ConsoleTable table = new ConsoleTable("ID", "Amount", "Description", "Date", "Category");
        expenses.ForEach(expense => table.AddRow(expense.Id, $"{expense.Amount:C4}", expense.Description, expense.Date, expense.Category.Name));
        table.Options.EnableCount = false;
        Console.Clear();
        table.Write(Format.MarkDown);
        Console.WriteLine("Enter any keyword to go back");
        Console.ReadKey();
    }

    public void CalculateTotalExpenses()
    {
        decimal total = expenseService.CalculateTotalExpenses();
        Console.Clear();
        Console.WriteLine($"Total expense: {total:C4}");
        Thread.Sleep(1500);
    }

    public void ExpensesByCategory()
    {
        int id;
        categoriesMenu.GetAll();
        Console.Write("Enter category Id ");
        while(!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid Id. Please enter a valid one.");
            Thread.Sleep(1000);
            categoriesMenu.GetAll();
            Console.Write("Enter category Id: ");
        }

        Category category = categoryService.GetById(id);
        if (category is not null)
        {
            List<Expense> expenses = expenseService.ExpensesByCategory(category);
            ConsoleTable table = new ConsoleTable("ID", "Amount", "Description", "Date", "Category");
            expenses.ForEach(expense => table.AddRow(expense.Id, $"{expense.Amount:C4}", expense.Description, expense.Date, expense.Category.Name));
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Console.WriteLine("Enter any keyword to go back");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Category was not found");
            Thread.Sleep(1000);
        }
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
