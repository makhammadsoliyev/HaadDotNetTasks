
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

    public List<TaskItem> GetAllTasks()
    {
        return tasks;
    }

    public TaskItem GetTask(int taskId)
    {
        return tasks.FirstOrDefault(task => task.TaskId == taskId);
    }

    public void SortTasksByDueDate(bool asc = true)
    {
        tasks = asc? tasks.OrderBy(task => task.DueDate).ToList() : tasks.OrderByDescending(task => task.DueDate).ToList();
    }

    public void TaskInfo(TaskItem task)
    {
        Console.WriteLine($"TaskId: {task.TaskId}, Description: {task.Description}, Due Date: {task.DueDate}");
    }
}
