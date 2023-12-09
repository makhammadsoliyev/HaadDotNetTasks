using StudentsManagementSystem.Enitites;
using StudentsManagementSystem.Interfaces;

namespace StudentsManagementSystem.Services;

public class SortService : ISortableService
{
    public void Sort(List<Student> students, string by)
    {
        students = by == "grade" ? students.OrderByDescending(student => student.Grade).ToList() :
            students.OrderByDescending(student => student.Name).ToList();
    }
}
