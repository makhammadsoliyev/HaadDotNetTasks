
namespace TaskManagementSystem;

public class TaskItem : ITask
{
    private int id;
    private string description;
    private DateTime dueDate;
    public int TaskId { get => id; set => id = value; }
    public string Description { get => description; set => description = value; }
    public DateTime DueDate { get => dueDate; set => dueDate = value; }

    public void DisplayTaskDetails()
    {
        Console.WriteLine($"TaskId: {TaskId}, Description: {Description}, Due Date: {dueDate}");
    }
}
