using C_Space.Services;
using ConsoleTables;

namespace C_Space.Display;

public class MainMenu
{
    private readonly UserManu userManu;
    private readonly PlaceMenu placeMenu;
    private readonly FeatureMenu featureMenu;
    private readonly BookingMenu bookingMenu;

    private readonly UserService userService;
    private readonly PlaceService placeService;
    private readonly FeatureService featureService;
    private readonly BookingService bookingService;

    public MainMenu()
    {
        this.userService = new UserService();
        this.placeService = new PlaceService();
        this.featureService = new FeatureService();
        this.bookingService = new BookingService(placeService, userService);

        this.userManu = new UserManu(userService);
        this.placeMenu = new PlaceMenu(placeService, featureService);
        this.featureMenu = new FeatureMenu(featureService);
        this.bookingMenu = new BookingMenu(bookingService);
    }

    public void Main()
    {
        bool circle = true;
        ConsoleTable table = DisplayChoices();
        string option;

        while (circle)
        {
            Console.Clear();
            table.Write(Format.MarkDown);
            Console.Write(">>> ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    userManu.Display();
                    break;
                case "2":
                    placeMenu.Display(); 
                    break;
                case "3":
                    featureMenu.Display();
                    break;
                case "4":
                    bookingMenu.Display();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
         
    }

    public static ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow("1", "User");
        table.AddRow("2", "Place");
        table.AddRow("3", "Feature");
        table.AddRow("4", "Booking");
        table.AddRow("0", "Exit");
        table.Options.EnableCount = false;

        return table;
    }
}
