using HaadLC.Interfaces;
using HaadLC.StudentService;

IStudentService studentService = new StudentService();
string opt;
bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("1. Add student.");
    Console.WriteLine("2. Delete student.");
    Console.WriteLine("3. Update student.");
    Console.WriteLine("4. Search student by Id.");
    Console.WriteLine("5. Search student by FirstName.");
    Console.WriteLine("6. Display all English students.");
    Console.WriteLine("7. Display all adult students.");
    Console.WriteLine("8. Display all students.");
    Console.WriteLine("9. Exit.");

    Console.Write("Enter your option: ");
    opt = Console.ReadLine();
    Console.Clear();

    switch (opt)
    {
        case "1":
            Console.Write("Enter student first name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid student name. Please enter a valid name.");
                Console.Write("Enter student name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter student birthDay: ");
            DateOnly birthDay;

            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out birthDay))
            {
                Console.WriteLine("Invalid student birthDay. Please enter a valid birthDay.");
                Console.Write("Enter student birthDay: ");
            }

            break;
    }

}




