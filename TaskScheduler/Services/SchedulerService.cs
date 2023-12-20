using TaskScheduler.Interfaces;
using TaskScheduler.Models;

namespace TaskScheduler.Services;

public class SchedulerService : ISchedulerService
{
    private readonly List<Scheduler> schedulers;
    public SchedulerService()
    {
        schedulers = new List<Scheduler>();
    }

    public Scheduler Create(Scheduler scheduler)
    {
        schedulers.Add(scheduler);
        return scheduler;
    }

    public bool Delete(int id)
    {
        var scheduler = schedulers.FirstOrDefault(scheduler => scheduler.Id == id);
        if (scheduler is null)
            throw new Exception("Schedule was not found");

        return schedulers.Remove(scheduler);
    }

    public List<Scheduler> GetAll()
        => schedulers;

    public Scheduler GetById(int id)
    {
        var scheduler = schedulers.FirstOrDefault(scheduler => scheduler.Id == id);
        if (scheduler is null)
            throw new Exception("Schedule was not found");

        return scheduler;
    }

    public Scheduler Update(int id, Scheduler scheduler)
    {
        var existScheduler = schedulers.FirstOrDefault(scheduler => scheduler.Id == id);
        if (existScheduler is null)
            throw new Exception("Schedule was not found");

        existScheduler.Id = id;
        existScheduler.Name = scheduler.Name;
        existScheduler.Tasks.AddRange(scheduler.Tasks);

        return existScheduler;
    }
}
