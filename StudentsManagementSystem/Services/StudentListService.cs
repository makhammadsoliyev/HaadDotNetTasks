using StudentsManagementSystem.Enitites;
using StudentsManagementSystem.Interfaces;

namespace StudentsManagementSystem.Services;

public class StudentListService : IStudentListService
{
    private List<Student> students;
    public StudentListService()
    {
        students = new List<Student>();
    }

    public void Add(Student student)
    {
        students.Add(student);
        Console.WriteLine("Successfully added...");
    }

    public void DisplayAll()
    {
        Console.WriteLine("All student");
        foreach (Student student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}, Birth Date: {student.BirthDate}");
        }
    }

    public void SearchByGrade(int grade)
    {
        var res = students.FindAll(student => student.Grade == grade);
        Console.WriteLine("All students");
        foreach (var s in res)
        {
            Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Grade: {s.Grade}, Birth Date: {s.BirthDate}");
        }
    }
    public void Sort(string by)
    {
        SortService service = new SortService();
        service.Sort(students, by);
        Console.WriteLine("Successfully sorted");
    }
}
