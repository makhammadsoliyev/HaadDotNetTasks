namespace TaskManagementSystem;

public interface ITask
{
    int TaskId { get; set; }
    string Description { get; set; }
    DateTime DueDate { get; set; }

    void DisplayTaskDetails();
}
