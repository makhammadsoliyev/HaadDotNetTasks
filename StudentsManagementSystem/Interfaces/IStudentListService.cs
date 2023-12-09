using StudentsManagementSystem.Enitites;

namespace StudentsManagementSystem.Interfaces;

public interface IStudentListService
{
    void Add(Student student);
    void DisplayAll();
    void SearchByGrade(decimal grade);
    void Sort(string by);
}
