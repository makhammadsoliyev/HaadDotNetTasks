using StudentsManagementSystem.Enitites;
using StudentsManagementSystem.Services;

StudentListService studentList = new StudentListService();
string opt;
bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("1. Add student.");
    Console.WriteLine("2. Display all students.");
    Console.WriteLine("3. Search students by grade.");
    Console.WriteLine("4. Sort student list");
    Console.WriteLine("5. Exit.");

    Console.Write("Enter your option: ");
    opt = Console.ReadLine();
    Console.Clear();
    switch (opt)
    {
        case "1":
            Console.Write("Enter student id: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Invalid student id. Please enter a valid id.");
                Console.Write("Enter student id: ");
            }

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid student name. Please enter a valid name.");
                Console.Write("Enter student name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter student grade(0-100): ");
            decimal grade;

            while (!decimal.TryParse(Console.ReadLine(), out grade) || (grade < 0 || grade > 100))
            {
                Console.WriteLine("Invalid student grade. Please enter a valid grade.");
                Console.Write("Enter student grade(0-100): ");
            }

            Console.Write("Enter student birthDay: ");
            DateOnly birthDay;

            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out birthDay))
            {
                Console.WriteLine("Invalid student birthDay. Please enter a valid birthDay.");
                Console.Write("Enter student birthDay: ");
            }
            Student student = new Student
            {
                Id = id,
                Name = name,
                Grade = grade,
                BirthDate = birthDay
            };
            studentList.Add(student);
            break;
        case "2":
            studentList.DisplayAll();
            break;
        case "3":
            Console.Write("Enter student grade(0-100): ");
            decimal g;

            while (!decimal.TryParse(Console.ReadLine(), out g) || (g < 0 || g > 100))
            {
                Console.WriteLine("Invalid student grade. Please enter a valid grade.");
                Console.Write("Enter student grade(0-100): ");
            }
            studentList.SearchByGrade(g);
            break;
        case "4":
            string option;
            Console.WriteLine("1. Sort by Grade");
            Console.WriteLine("2. Sort by Name");
            while (true)
            {
                Console.Write("Enter your choice: ");
                option = Console.ReadLine();
                if (option == "1")
                {
                    studentList.Sort("grade");
                    break;
                }
                else if (option == "2")
                {
                    studentList.Sort("name");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a valid one.");
                }
            }
            break;
        case "5":
            Console.WriteLine("GoodBye");
            isTrue = false;
            break;
    }
    Console.WriteLine();
}

