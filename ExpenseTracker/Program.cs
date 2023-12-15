using System;
using ConsoleTables;

class Program
{
    static void Main()
    {
        // Your table data
        var table = new ConsoleTable("ID", "Name", "Age");
        table.AddRow(1, "Alice", 25);
        table.AddRow(2, "Bob", 30);
        table.AddRow(3, "Charlie", 28);

        // Display the table with a name
        PrintTableWithTitle("User Information", table);
    }

    static void PrintTableWithTitle(string title, ConsoleTable table)
    {
        // Print the title
        Console.WriteLine(title);

        // Print a separator line
        Console.WriteLine(new string('-', title.Length));

        // Print the table
        Console.WriteLine(table.ToString());
    }
}
