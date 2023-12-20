using TaskScheduler.Models;

namespace TaskScheduler.Interfaces;

public interface ISchedulerService
{
    Scheduler Create(Scheduler scheduler);
    Scheduler Update(int id, Scheduler scheduler);
    bool Delete(int id);
    Scheduler GetById(int id);
    List<Scheduler> GetAll();
}
