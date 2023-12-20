using ConsoleTables;
using TaskScheduler.Models;
using TaskScheduler.Services;

namespace TaskScheduler.Display;

public class SchedulerMenu
{
    private readonly SchedulerService schedulerService;
    private readonly TaskService taskService;

    public SchedulerMenu(SchedulerService schedulerService, TaskService taskService)
    {
        this.taskService = taskService;
        this.schedulerService = schedulerService;
    }

    private void Create()
    {
        string name;

        Console.Clear();
        Console.Write("Name: ");
        name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            Console.Write("Name: ");
        }

        var scheduler = new Scheduler()
        {
            Name = name
        };

        int taskId;

        while (true)
        {
            Console.Write("TaskId(0. Skip or Finish): ");
            while (!int.TryParse(Console.ReadLine(), out taskId) || taskId < 0)
            {
                Console.WriteLine("Invalid taskId.");
                Console.Write("TaskId(0. Skip or Finish): ");
            }

            if (taskId == 0) break;

            try
            {
                var task = taskService.GetById(taskId);
                scheduler.Tasks.Add(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        schedulerService.Create(scheduler);
        Console.WriteLine("Successfully created...");
        Thread.Sleep(1500);
    }

    private void GetById()
    {
        int id;

        Console.Clear();
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id");
            Console.Write("Id: ");
        }

        try
        {
            var scheduler = schedulerService.GetById(id);
            var table = new ConsoleTable("Id", "Name", "Tasks");

            table.AddRow(scheduler.Id, scheduler.Name, string.Join(", ", scheduler.Tasks.Select(task => task.Title)));
            table.Options.EnableCount = false;
            Console.Clear();
            table.Write(Format.MarkDown);
            Console.WriteLine("Press any keyboard to continue...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Thread.Sleep(1500);
        }
    }

    private void Update()
    {
        int id;

        Console.Clear();
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id");
            Console.Write("Id: ");
        }

        string name;

        Console.Clear();
        Console.Write("Name: ");
        name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            Console.Write("Name: ");
        }

        var scheduler = new Scheduler()
        {
            Name = name
        };

        int taskId;

        while (true)
        {
            Console.Write("TaskId(0. Skip or Finish): ");
            while (!int.TryParse(Console.ReadLine(), out taskId) || taskId < 0)
            {
                Console.WriteLine("Invalid taskId.");
                Console.Write("TaskId(0. Skip or Finish): ");
            }

            if (taskId == 0) break;

            try
            {
                var task = taskService.GetById(taskId);
                scheduler.Tasks.Add(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        try
        {
            schedulerService.Update(id, scheduler);
            Console.WriteLine("Successfully updated...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    private void Delete()
    {
        int id;

        Console.Clear();
        Console.Write("Id: ");
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid id");
            Console.Write("Id: ");
        }

        try
        {
            schedulerService.Delete(id);
            Console.WriteLine("Successfully deleted...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    private void GetAll()
    {
        var schedulers = schedulerService.GetAll();
        var table = new ConsoleTable("Id", "Name", "Tasks");

        foreach (var scheduler in schedulers)
        {
            table.AddRow(scheduler.Id, scheduler.Name, string.Join(", ", scheduler.Tasks.Select(task => task.Title)));
        }
        Console.Clear();
        table.Options.EnableCount = false;
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyboard to continue...");
        Console.ReadKey();
    }

    private ConsoleTable DisplayTable()
    {
        var table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Create");
        table.AddRow(2, "GetById");
        table.AddRow(3, "Update");
        table.AddRow(4, "Delete");
        table.AddRow(5, "GetAll");
        table.AddRow(0, "Back");

        table.Options.EnableCount = false;

        return table;
    }

    public void Display()
    {
        var table = DisplayTable();
        var circle = true;
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
                    GetById(); 
                    break;
                case "3":
                    Update();
                    break;
                case "4": 
                    Delete(); 
                    break;
                case "5":
                    GetAll(); 
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
