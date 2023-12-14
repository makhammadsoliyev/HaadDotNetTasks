using ConsoleTables;

namespace LibraryManagementSystem.Menus;

public class MainMenu
{
    public void Main()
    {
        ConsoleTable displayMenu = DisplayMenu();
        BookMenu booMenu = new BookMenu();
        bool circle = true;

        while (circle)
        {
            //Console.WriteLine(table);
            Console.Clear();
            displayMenu.Write(Format.MarkDown);
            Console.Write(">>> ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "1":
                    // BookMenu
                    booMenu.Display();
                    break;
                case "2":
                    // MemberMenu
                    break;
                case "0":
                    // exit
                    circle = false;
                    break;
            }
        }
        
    }
    public static ConsoleTable DisplayMenu()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Books");
        table.AddRow(2, "Members");
        table.AddRow(0, "Exit");
        table.Options.EnableCount = false;
        return table;
    }
}
