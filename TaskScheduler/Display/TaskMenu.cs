using ConsoleTables;
using System.Threading.Tasks;
using TaskScheduler.Models;
using TaskScheduler.Services;

namespace TaskScheduler.Display;

public class TaskMenu
{
    private readonly TaskService taskService;

    public TaskMenu(TaskService taskService)
    {
        this.taskService = taskService;
    }

    private void Create()
    {
        string title;

        Console.Clear();
        Console.Write("Title: ");
        title = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid title.");
            Console.Write("Title: ");
            title = Console.ReadLine();
        }

        string description;

        Console.Write("Description: ");
        description = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Invalid description.");
            Console.Write("Description: ");
            description = Console.ReadLine();
        }

        TimeOnly dueDate;

        Console.Write("DueDate(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm",
             out dueDate))
        {
            Console.WriteLine("Invalid format.");
            Console.Write("DueDate(HH:mm): ");
        }

        var task = new TaskModel()
        {
            Title = title,
            DueDate = dueDate,
            Description = description
        };

        taskService.Create(task);
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
            var task = taskService.GetById(id);
            var table = new ConsoleTable("Id", "Title", "Description", "DueDate", "Status");
            table.AddRow(task.Id, task.Title, task.Description, task.DueDate, task.Status);
            Console.Clear();
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

        string title;

        Console.Write("Title: ");
        title = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid title.");
            Console.Write("Title: ");
            title = Console.ReadLine();
        }

        string description;

        Console.Write("Description: ");
        description = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Invalid description.");
            Console.Write("Description: ");
            description = Console.ReadLine();
        }

        TimeOnly dueDate;

        Console.Write("DueDate(HH:mm): ");
        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out dueDate))
        {
            Console.WriteLine("Invalid format.");
            Console.Write("DueDate(HH:mm): ");
        }

        string status;

        Console.Clear();
        Console.Write("Status(1. Completed. 0. Pending): ");
        status = Console.ReadLine();
        while (status != "1" && status != "0")
        {
            Console.WriteLine("Invalid status");
            Console.Write("status: ");
            status = Console.ReadLine();
        }

        var task = new TaskModel()
        {
            Description = description,
            DueDate = dueDate,
            Title = title,
            Id = id,
            Status = (Status)Convert.ToInt32(status)
        };

        try
        {
            taskService.Update(id, task);
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
            taskService.Delete(id);
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
        var tasks = taskService.GetAll();
        var table = new ConsoleTable("Id", "Title", "Description", "DueDate", "Status");

        foreach ( var task in tasks )
            table.AddRow(task.Id, task.Title, task.Description, task.DueDate, task.Status);

        table.Options.EnableCount = false;
        Console.Clear();
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyboard to continue...");
        Console.ReadKey();
    }

    private void GetCompletedTasks()
    {
        var tasks = taskService.GetCompletedTasks();
        var table = new ConsoleTable("Id", "Title", "Description", "DueDate", "Status");

        foreach (var task in tasks)
            table.AddRow(task.Id, task.Title, task.Description, task.DueDate, task.Status);

        table.Options.EnableCount = false;
        Console.Clear();
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyboard to continue...");
        Console.ReadKey();
    }

    private void GetPendingTasks()
    {
        var tasks = taskService.GetPendingTasks();
        var table = new ConsoleTable("Id", "Title", "Description", "DueDate", "Status");

        foreach (var task in tasks)
            table.AddRow(task.Id, task.Title, task.Description, task.DueDate, task.Status);

        table.Options.EnableCount = false;
        Console.Clear();
        table.Write(Format.MarkDown);
        Console.WriteLine("Press any keyboard to continue...");
        Console.ReadKey();
    }

    private void MarkAsCompleted()
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
            taskService.MarkAsCompleted(id);
            Console.WriteLine("Successfully completed...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(1500);
    }

    private ConsoleTable DisplayTable()
    {
        var table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Create");
        table.AddRow(2, "GetById");
        table.AddRow(3, "Update");
        table.AddRow(4, "Delete");
        table.AddRow(5, "GetAll");
        table.AddRow(6, "GetCompletedTasks");
        table.AddRow(7, "GetPendingTasks");
        table.AddRow(8, "MarkAsCompleted");
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
                case "6":
                    GetCompletedTasks();
                    break;
                case "7":
                    GetPendingTasks();
                    break;
                case "8":
                    MarkAsCompleted();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
