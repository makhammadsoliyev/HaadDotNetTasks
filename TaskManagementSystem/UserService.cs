
namespace TaskManagementSystem;

public class UserService : IUserService
{
    private List<TaskItem> tasks;
    public UserService()
    {
        tasks = new List<TaskItem>();
    }
    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
        Console.WriteLine("Task successfully added...");
    }

    public bool DeleteTask(int taskId)
    {
        return tasks.Remove(GetTask(taskId));
    }

    public TaskItem GetTask(int taskId)
    {
        return tasks.FirstOrDefault(task => task.TaskId == taskId);
    }
}
