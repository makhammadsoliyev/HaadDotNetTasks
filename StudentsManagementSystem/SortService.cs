
namespace StudentsManagementSystem;

public class SortService : ISortable
{
    public void Sort(List<Student> students, string by)
    {
        students = by=="grade" ? students.OrderByDescending(student => student.Grade).ToList() :
            students.OrderByDescending(student => student.Name).ToList();
    }
}
