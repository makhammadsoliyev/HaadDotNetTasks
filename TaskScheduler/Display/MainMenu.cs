using ConsoleTables;
using System.Diagnostics;
using TaskScheduler.Services;

namespace TaskScheduler.Display;

public class MainMenu
{
    private readonly TaskService taskService;
    private readonly SchedulerService schedulerService;

    private readonly TaskMenu taskMenu;
    private readonly SchedulerMenu schedulerMenu;
    public MainMenu()
    {
        this.taskService = new TaskService();
        this.schedulerService = new SchedulerService();

        this.taskMenu = new TaskMenu(taskService);
        this.schedulerMenu = new SchedulerMenu(schedulerService, taskService);
    }

    private ConsoleTable DisplayTable()
    {
        var table = new ConsoleTable("N", "Options");
        table.AddRow(1, "Tasks");
        table.AddRow(2, "Schedules");
        table.AddRow(0, "Exit");

        table.Options.EnableCount = false;

        return table;
    }

    public void Display()
    {
        var circle = true;
        var table = DisplayTable();
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
                    taskMenu.Display();
                    break;
                case "2":
                    schedulerMenu.Display();
                    break;
                case "0":
                    circle = false;
                    break;
            }
        }
    }
}
