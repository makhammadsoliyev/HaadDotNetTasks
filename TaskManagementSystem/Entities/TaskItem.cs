using TaskManagementSystem.Interfaces;

namespace TaskManagementSystem.Entities;

public class TaskItem : ITask
{
    private int id = 0;
    private string description;
    private DateOnly dueDate;
    public TaskItem()
    {
        //TaskId = ++id;
    }
    public int TaskId { get => id; set => id = value; }
    public string Description { get => description; set => description = value; }
    public DateOnly DueDate { get => dueDate; set => dueDate = value; }

    public void DisplayTaskDetails()
    {
        Console.WriteLine($"TaskId: {TaskId}, Description: {Description}, Due Date: {dueDate}");
    }
}
