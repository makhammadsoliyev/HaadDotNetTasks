namespace TaskManagementSystem;

public interface IUserService
{
    void AddTask(TaskItem task);
    bool DeleteTask(int taskId);
    TaskItem GetTask(int taskId);
}
