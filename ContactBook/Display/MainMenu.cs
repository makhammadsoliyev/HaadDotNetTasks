using ContactBook.Services;
using Spectre.Console;

namespace ContactBook.Display;

public class MainMenu
{
    private readonly GroupMenu groupMenu;
    private readonly ContactMenu contactMenu;

    private readonly GroupService groupService;
    private readonly ContactService contactService;

    public MainMenu()
    {
        this.contactService = new ContactService();
        this.groupService = new GroupService(contactService);

        this.groupMenu = new GroupMenu(groupService);
        this.contactMenu = new ContactMenu(contactService);
    }

    public void Display()
    {
        var selectionDisplay = new SelectionDisplay();
        var circle = true;

        while (circle)
        {
            Console.Clear();
            var selectionTable = selectionDisplay.SelectionTable("Contacts", "Groups", "[red]Exit[/]");
            AnsiConsole.WriteLine();
            switch (selectionTable)
            {
                case "Contacts":
                    contactMenu.Display(); 
                    break;
                case "Groups":
                    groupMenu.Display(); 
                    break;
                case "[red]Exit[/]":
                    circle = false;
                    break;
            }
        }
    }
}
