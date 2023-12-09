using HaadLC.Entities;

namespace HaadLC.Interfaces;

public interface IStudentService
{
    void CreateStudent (Student student);
    void UpdateStudent (long id, Student student);
    bool DeleteStudent (long id);
    Student GetById(long id);
    Student GetByFirstName(string firstName);
    List<Student> GetAllEnglishStudents();
    List<Student> GetAllAdults();
    List<Student> GetAll();
}
