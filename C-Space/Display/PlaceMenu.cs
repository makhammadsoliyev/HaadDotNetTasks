using C_Space.Models;
using C_Space.Services;
using ConsoleTables;
using System.Linq;

namespace C_Space.Display;

public class PlaceMenu
{
    private readonly PlaceService placeService;
    private readonly FeatureService featureService;

    public PlaceMenu(PlaceService placeService, FeatureService featureService)
    {
        this.placeService = placeService;
        this.featureService = featureService;
    }

    public void Create()
    {
        Place place = new Place();

        string number;
        Console.Write("Number: ");
        number = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(number))
        {
            Console.WriteLine("Invalid number");
            Console.Write("Number: ");
            number = Console.ReadLine();
        }

        int floor;
        Console.Write("Floor: ");
        while (!int.TryParse(Console.ReadLine(), out floor) || 0 >= floor)
        {
            Console.WriteLine("Invalid floor.");
            Console.Write("Floor: ");
        }

        string room;
        Console.Write("Room: ");
        room = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(room))
        {
            Console.WriteLine("Invalid room");
            Console.Write("Room: ");
            room = Console.ReadLine();
        }

        decimal price;
        Console.Write("Price: ");
        while (!decimal.TryParse(Console.ReadLine(), out price) || 0 >= price)
        {
            Console.WriteLine("Invalid price.");
            Console.Write("Price: ");
        }

        int featureId;
        while (true)
        {
            Console.Write("FeatureId (0 is to skip or to finish): ");
            while (!int.TryParse(Console.ReadLine(), out featureId) || 0 > featureId)
            {
                Console.WriteLine("Invalid featureId.");
                Console.Write("FeatureId (0 is to skip or to finish): ");
            }
            if (featureId == 0) break;
            try
            {
                Feature feature = featureService.GetById(featureId);
                place.Features.Add(feature);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        place.Room = room;
        place.Price = price;
        place.Floor = floor;
        place.Number = number;

        try
        {
            placeService.Create(place);
            Console.WriteLine("Successfully created...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    public void Update()
    {
        Place place = new Place();

        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        string number;
        Console.Write("Number: ");
        number = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(number))
        {
            Console.WriteLine("Invalid number");
            Console.Write("Number: ");
            number = Console.ReadLine();
        }

        int floor;
        Console.Write("Floor: ");
        while (!int.TryParse(Console.ReadLine(), out floor) || 0 >= floor)
        {
            Console.WriteLine("Invalid floor.");
            Console.Write("Floor: ");
        }

        string room;
        Console.Write("Room: ");
        room = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(room))
        {
            Console.WriteLine("Invalid room");
            Console.Write("Room: ");
            room = Console.ReadLine();
        }

        decimal price;
        Console.Write("Price: ");
        while (!decimal.TryParse(Console.ReadLine(), out price) || 0 >= price)
        {
            Console.WriteLine("Invalid price.");
            Console.Write("Price: ");
        }

        int featureId;
        while (true)
        {
            Console.Write("FeatureId (0 is to skip or to finish): ");
            while (!int.TryParse(Console.ReadLine(), out featureId) || 0 > featureId)
            {
                Console.WriteLine("Invalid featureId.");
                Console.Write("FeatureId (0 is to skip or to finish): ");
            }
            if (featureId == 0) break;
            try
            {
                Feature feature = featureService.GetById(featureId);
                place.Features.Add(feature);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        place.Room = room;
        place.Price = price;
        place.Floor = floor;
        place.Number = number;

        try
        {
            placeService.Update(id, place);
            Console.WriteLine("Successfully updated...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
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
            placeService.Delete(id);
            Console.WriteLine("Successfully deleted...");
        }
        catch(Exception ex) 
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
            Place place = placeService.GetById(id);
            ConsoleTable table = new ConsoleTable("ID", "Number", "Floor", "Room", "IsAvailable", "Price", "Features");

            table.AddRow(place.Id, place.Number, place.Floor, place.Room, place.IsAvailable, $"{place.Price:C4}",
                string.Join(", ", place.Features.Select(feature => feature.Name).ToList()));
            table.Options.EnableCount = false;
            table.Write(Format.MarkDown);
            Console.WriteLine("Press any keyword to continue");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void GetAll()
    {
        List<Place> places = placeService.GetAll();
        ConsoleTable table = new ConsoleTable("ID", "Number", "Floor", "Room", "IsAvailable", "Price", "Features");
        foreach (Place place in places)
        {
            table.AddRow(place.Id, place.Number, place.Floor, place.Room, place.IsAvailable, $"{place.Price:C4}",
                string.Join(", ", place.Features.Select(feature => feature.Name).ToList()));
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyword to continue");
        Console.ReadKey();
    }

    public void GetAvailablePlacesList()
    {
        List<Place> places = placeService.GetAvailablePlacesList();
        ConsoleTable table = new ConsoleTable("ID", "Number", "Floor", "Room", "IsAvailable", "Price", "Features");
        foreach (Place place in places)
        {
            table.AddRow(place.Id, place.Number, place.Floor, place.Room, place.IsAvailable, $"{place.Price:C4}",
                string.Join(", ", place.Features.Select(feature => feature.Name).ToList()));
        }
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyword to continue");
        Console.ReadKey();
    }

    public static ConsoleTable DisplayChoices()
    {
        ConsoleTable table = new ConsoleTable("N", "Options");
        table.AddRow("1", "Create");
        table.AddRow("2", "Update");
        table.AddRow("3", "GetById");
        table.AddRow("4", "GetAll");
        table.AddRow("5", "GetAvailablePlacesList");
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
                    GetAll();
                    break;
                case "5":
                    GetAvailablePlacesList();
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
