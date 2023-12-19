using C_Space.Models;
using C_Space.Services;
using ConsoleTables;

namespace C_Space.Display;

public class FeatureMenu
{
    private readonly FeatureService featureService;

    public FeatureMenu(FeatureService featureService)
    {
        this.featureService = featureService;
    }

    public void Create()
    {
        Feature feature;
        string name;
        Console.Write("Name: ");
        name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        feature = new Feature()
        {
            Name = name
        };

        featureService.Create(feature);
        Console.WriteLine("Successfully created...");
        Thread.Sleep(1500);    
    }

    public void Update()
    {
        Feature feature;

        int id;
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || 0 >= id)
        {
            Console.WriteLine("Invalid id.");
            Console.Write("Id: ");
        }

        string name;
        Console.Write("Name: ");
        name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        feature = new Feature()
        {
            Name = name
        };

        try
        {
            featureService.Update(id, feature);
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
            featureService.Delete(id);
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
            Feature feature = featureService.GetById(id);
            ConsoleTable table = new ConsoleTable("ID", "Name");
            table.AddRow(feature.Id, feature.Name);
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

    public void GetAll()
    {
        List<Feature> features = featureService.GetAll();
        ConsoleTable table = new ConsoleTable("ID", "Name");

        foreach (var feature in features)
        {
            table.AddRow(feature.Id, feature.Name);
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
        table.AddRow("5", "Delete");
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
                    Delete();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
