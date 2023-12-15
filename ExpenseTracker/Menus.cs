using ConsoleTables;

namespace ExpenseTracker;

public class Menus
{
    public static void Main(string[] args)
    {
        // ExpensesMenu
        // CategoriesMenu
        ConsoleTable table = new ConsoleTable("N", "Option");
        table.AddRow(1, "Expenses");
        table.AddRow(2, "Categories");
        table.AddRow(0, "Exit");


    }
    
}
