using HaadLC.Entities;
using HaadLC.Interfaces;

namespace HaadLC.StudentService;

public class StudentService : IStudentService
{
    List<Student> students;
    public StudentService()
    {
        students = new List<Student>();
    }
    public void CreateStudent(Student student)
    {
        students.Add(student);
    }

    public bool DeleteStudent(long id)
    {
        return students.Remove(GetById(id));
    }

    public List<Student> GetAll()
    {
        return students;
    }

    public List<Student> GetAllAdults()
    {
        //return students.FindAll(student => DateTime.Now.Year - student.DateOfBirth.Year >= 18);
        return students.FindAll(student => DateTime.Now.Year - student.DateOfBirth.Year >= 18);
    }

    public List<Student> GetAllEnglishStudents()
    {
        return students.FindAll(student => student.Subject == Subject.English);
    }

    public Student GetByFirstName(string firstName)
    {
        return students.FirstOrDefault(student => student.FirstName == firstName);
    }

    public Student GetById(long id)
    {
        return students.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateStudent(long id, Student student)
    {
        int index = students.FindIndex(student => student.Id == id);
        if (index < 0)
        {
            Console.WriteLine("Student was not found...");
        }
        else
        {
            student.Id = id;
            students[index] = student;
            Console.WriteLine("Successfully added...");
        }
    }
}
