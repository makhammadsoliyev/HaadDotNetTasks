using C_Space.Models;
using C_Space.Services;
using ConsoleTables;

namespace C_Space.Display;

public class BookingMenu
{
    private readonly BookingService bookingService;

    public BookingMenu(BookingService bookingService)
    {
        this.bookingService = bookingService;
    }

    public void Create()
    {
        Booking booking;

        int userId;
        Console.Write("UserId: ");
        while (!int.TryParse(Console.ReadLine(), out userId) || 0 >= userId)
        {
            Console.WriteLine("Invalid userId.");
            Console.Write("UserId: ");
        }

        int placeId;
        Console.Write("PlaceId: ");
        while (!int.TryParse(Console.ReadLine(), out placeId) || 0 >= placeId)
        {
            Console.WriteLine("Invalid placeId.");
            Console.Write("PlaceId: ");
        }

        TimeOnly startTime;
        Console.Write("StartTime(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out startTime))
        {
            Console.WriteLine("Invalid time");
            Console.Write("StartTime(HH:mm): ");
        }

        TimeOnly endTime;
        Console.Write("EndTime(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out endTime))
        {
            Console.WriteLine("Invalid time");
            Console.Write("EndTime(HH:mm): ");
        }

        try
        {
            booking = new Booking()
            {
                UserId = userId,
                PlaceId = placeId,
                StartTime = startTime,
                EndTime = endTime
            };
            Console.WriteLine("Successfully created");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void Update()
    {
        Booking booking;

        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        int userId;
        Console.Write("UserId: ");
        while (!int.TryParse(Console.ReadLine(), out userId) || 0 >= userId)
        {
            Console.WriteLine("Invalid userId.");
            Console.Write("UserId: ");
        }

        int placeId;
        Console.Write("PlaceId: ");
        while (!int.TryParse(Console.ReadLine(), out placeId) || 0 >= placeId)
        {
            Console.WriteLine("Invalid placeId.");
            Console.Write("PlaceId: ");
        }

        TimeOnly startTime;
        Console.Write("StartTime(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out startTime))
        {
            Console.WriteLine("Invalid time");
            Console.Write("StartTime(HH:mm): ");
        }

        TimeOnly endTime;
        Console.Write("EndTime(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out endTime))
        {
            Console.WriteLine("Invalid time");
            Console.Write("EndTime(HH:mm): ");
        }

        booking = new Booking()
        {
            UserId = userId,
            PlaceId = placeId,
            StartTime = startTime,
            EndTime = endTime
        };

        try
        {
            bookingService.Update(id, booking);
            Console.WriteLine("Successfully updated...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete()
    {
        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        try
        {
            bookingService.Delete(id);
            Console.WriteLine("Successfully deleted...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void GetById()
    {
        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        try
        {
            Booking booking = bookingService.GetById(id);
            ConsoleTable table = new ConsoleTable("ID", "UserId", "PlaceId", "StartTime", "EndTime");
            table.AddRow(booking.Id, booking.UserId, booking.PlaceId, booking.StartTime, booking.EndTime);
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Console.WriteLine("Press any keyword to continue");
            Console.ReadKey();
        }
        catch  (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Thread.Sleep(1500);
        }
    }

    public void GetAll()
    {
        List<Booking> bookings = bookingService.GetAll();
        ConsoleTable table = new ConsoleTable("ID", "UserId", "PlaceId", "StartTime", "EndTime");
        foreach (var booking in bookings)
        {
            table.AddRow(booking.Id, booking.UserId, booking.PlaceId, booking.StartTime, booking.EndTime);
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyword to continue");
        Console.ReadKey();
    }

    public void GetByUserId()
    {
        int userId;
        Console.Write("UserId: ");
        while (!int.TryParse(Console.ReadLine(), out userId) || 0 >= userId)
        {
            Console.WriteLine("Invalid userId.");
            Console.Write("UserId: ");
        }

        try
        {
            (string placeNumber, TimeOnly startTime, TimeOnly endTime) = bookingService.GetByUserId(userId);
            ConsoleTable table = new ConsoleTable("UserId", "PlaceNumber", "StartTime", "EndTime");
            table.AddRow(userId, placeNumber, startTime, endTime);
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Console.WriteLine("Press any keyword to continue");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Thread.Sleep(1500);
        }

    }

    public static ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow("1", "Create");
        table.AddRow("2", "Update");
        table.AddRow("3", "GetById");
        table.AddRow("4", "GetByUserId");
        table.AddRow("5", "GetAll");
        table.AddRow("6", "Delete");
        table.AddRow("0", "Back");
        table.Options.EnableCount = false;

        return table;
    }

    public void Display()
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
                    Create();
                    break;
                case "2":
                    Update();
                    break;
                case "3":
                    GetById();
                    break;
                case "4":
                    GetByUserId();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    Delete();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
