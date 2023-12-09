using StudentsManagementSystem.Enitites;

namespace StudentsManagementSystem.Interfaces;

public interface ISortableService
{
    void Sort(List<Student> students, string by);
}
