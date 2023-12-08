namespace StudentsManagementSystem;

public interface IStudentList
{
    void Add(Student student);
    void DisplayAll();
    void SearchByGrade(decimal grade);
    void Sort(string by);
}
