namespace TaskManagementSystem;

public interface ITask
{
    int TaskId { get; set; }
    string Description { get; set; }
    DateOnly DueDate { get; set; }

    void DisplayTaskDetails();
}
