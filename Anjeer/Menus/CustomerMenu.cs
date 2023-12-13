using ConsoleTables;

namespace Anjeer.Menus;

public class CustomerMenu
{
    public void Create()
    {

    }
    public void Update()
    {

    }
    public void Delete()
    {

    }
    public void GetById()
    {

    }
    public void GetAll()
    {

    }
    public void DisplayChoices()
    {
        var table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Create");
        table.AddRow(2, "Update");
        table.AddRow(3, "Delete");
        table.AddRow(4, "GetById");
        table.AddRow(5, "GetAll");
        table.AddRow(6, "Go Back");
        Console.Clear();
        Console.WriteLine(table);
    }
    public void Display()
    {
        DisplayChoices();
    } 
}
