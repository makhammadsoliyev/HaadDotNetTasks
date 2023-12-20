using System.Net.NetworkInformation;

namespace TaskScheduler.Models;

public class TaskModel
{
    private static int id = 0;
    public TaskModel()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeOnly DueDate { get; set; }
    public Status Status { get; set; } = Status.Pending;
}
