namespace StudentsManagementSystem.Enitites;

public class Student
{
    private int grade;

    public int Id { get; set; }
    public string Name { get; set; }
    public int Grade { get => grade; set => grade = value; }
    public DateOnly BirthDate { get; set; }
}
