using TaskScheduler.Models;

namespace TaskScheduler.Interfaces;

public interface ITaskService
{
    TaskModel Create(TaskModel task);
    TaskModel Update(int id, TaskModel task);
    bool Delete(int id);
    TaskModel GetById(int id);
    List<TaskModel> GetAll();
    List<TaskModel> GetPendingTasks();
    List<TaskModel> GetCompletedTasks();
    TaskModel MarkAsCompleted(int id);
}
