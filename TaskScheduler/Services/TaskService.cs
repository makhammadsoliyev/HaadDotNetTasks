using TaskScheduler.Interfaces;
using TaskScheduler.Models;

namespace TaskScheduler.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskModel> tasks;
    public TaskService()
    {
        tasks = new List<TaskModel>();
    }
    public TaskModel Create(TaskModel task)
    {
        tasks.Add(task);
        return task;
    }

    public bool Delete(int id)
    {
        var task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
        {
            throw new Exception("Task was not found");
        }

        return tasks.Remove(task);
    }

    public List<TaskModel> GetAll()
        => tasks;

    public TaskModel GetById(int id)
    {
        var task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
            throw new Exception("Task was not found");

        return task;
    }

    public List<TaskModel> GetCompletedTasks()
        => tasks.Where(task => task.Status == Status.Completed).ToList();

    public List<TaskModel> GetPendingTasks()
        => tasks.Where(task => task.Status == Status.Pending).ToList();

    public TaskModel MarkAsCompleted(int id)
    {
        var task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
            throw new Exception("Task was not found");

        task.Status = Status.Completed;
        return task;
    }

    public TaskModel Update(int id, TaskModel task)
    {
        var existTask = tasks.FirstOrDefault(task => task.Id == id);
        if (existTask is null)
            throw new Exception("Task was not found");

        existTask.Id = id;
        existTask.Title = task.Title;
        existTask.Status = task.Status;
        existTask.DueDate = task.DueDate;
        existTask.Description = task.Description;

        return existTask;
    }
}
