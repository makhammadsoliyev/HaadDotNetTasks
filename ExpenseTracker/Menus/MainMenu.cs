using ConsoleTables;

namespace ExpenseTracker.Menus;

public class MainMenu
{
    public static void Main()
    {
        // ExpensesMenu
        ExpensesMenu expensesMenu = new ExpensesMenu();
        // CategoriesMenu
        CategoriesMenu categoriesMenu = new CategoriesMenu();
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
                    expensesMenu.Display();
                    break;
                case "2":
                    categoriesMenu.Display(); 
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }

    private static ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Option");
        table.AddRow(1, "Expenses");
        table.AddRow(2, "Categories");
        table.AddRow(0, "Exit");
        table.Options.EnableCount = false;
        return table;
    }

}
