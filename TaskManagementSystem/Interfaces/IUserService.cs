using TaskManagementSystem.Enitites;

namespace TaskManagementSystem.Interfaces;

public interface IUserService
{
    void AddTask(TaskItem task);
    bool DeleteTask(int taskId);
    void TaskInfo(TaskItem task);
    TaskItem GetTask(int taskId);
    List<TaskItem> GetAllTasks();
    void SortTasksByDueDate(bool asc = true);
}
