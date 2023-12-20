namespace TaskScheduler.Models;

public class Scheduler
{
    private static int id = 0;
    public Scheduler()
    {
        Id = ++id;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
