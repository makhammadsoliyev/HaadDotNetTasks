using ConsoleTables;
using ExpenseTracker.Services;

namespace ExpenseTracker.Menus;

public class CategoriesMenu
{
    private CategoryService categoryService;
    public CategoriesMenu()
    {
        categoryService = new CategoryService();
    }
    private void Add()
    {

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

    private ConsoleTable DisplayChoices()
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
