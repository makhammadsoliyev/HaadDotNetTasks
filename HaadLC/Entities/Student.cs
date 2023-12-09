namespace HaadLC.Entities;

public class Student
{
    private static long id = 0;
    public Student()
    {
        Id = ++id;
    }
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Subject Subject { get; set; }
}
