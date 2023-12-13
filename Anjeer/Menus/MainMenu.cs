using ConsoleTables;


namespace Anjeer.Menus;

public class MainMenu
{
    public void Main()
    {
        bool circle = true;
        while (circle)
        {
            var table = new ConsoleTable("N", "Options");
            table.AddRow(1, "Customers");
            table.AddRow(2, "Employees");
            table.AddRow(3, "Cards");
            table.AddRow(4, "Transactions");
            table.AddRow(5, "Exit");

            //Console.Clear();
            Console.WriteLine(table);

            Console.Write("Enter option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.Display();
                    break;
                case "2":
                    EmployeeMenu employeeMenu = new EmployeeMenu();
                    employeeMenu.Display();
                    break;
                case "3":
                    CardMenu cardMenu = new CardMenu();
                    cardMenu.Display();
                    break;
                case "4":
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.Display();
                    break; 
                case "5":
                    circle = false;
                    break;
            }
        }
    }
}
