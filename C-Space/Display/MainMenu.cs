using C_Space.Services;

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
        this.placeMenu = new PlaceMenu(placeService);
        this.featureMenu = new FeatureMenu(featureService);
        this.bookingMenu = new BookingMenu(bookingService);
    }
}
