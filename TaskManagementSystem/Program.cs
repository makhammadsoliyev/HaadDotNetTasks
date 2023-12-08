
using System.Globalization;
using TaskManagementSystem;

IUserService service = new UserService();

while (true)
{
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Task info");
    Console.WriteLine("3. Display all tasks");
    Console.WriteLine("4. Sort tasks by Due Date");
    Console.WriteLine("5. Remove task");
    Console.Write("Enter your option[1-5]: ");

    string opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            Console.Write("Enter taskId: ");
            int taskId;
            while (!int.TryParse(Console.ReadLine().Trim(), out taskId) || taskId < 0)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id.");
                Console.Write("Enter taskId: ");
            }

            Console.Write("Enter task description: ");
            string taskDescription = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(taskDescription))
            {
                Console.WriteLine("Task description cannot be empty. Please enter a valid description.");
                Console.Write("Enter task description: ");
                taskDescription = Console.ReadLine().Trim();
            }

            Console.Write("Enter task due date:(dd/mm/yy): ");
            DateOnly dueDate;
            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out dueDate))
            {
                Console.WriteLine("Invalid DueDate. Please enter a valid Date.");
                Console.Write("Enter task due date:(dd/mm/yy): ");
            }

            TaskItem task = new TaskItem
            {
                TaskId = taskId,
                Description = taskDescription,
                DueDate = dueDate
            };
            Console.Clear();
            service.AddTask(task);
            break;
        case "2":
            Console.Write("Enter taskId: ");
            int Id;
            while (!int.TryParse(Console.ReadLine().Trim(), out Id) || Id < 0)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id.");
                Console.Write("Enter taskId: ");
            }

            Console.Clear();
            TaskItem taskItem = service.GetTask(Id);
            if (taskItem == null)
            {
                Console.WriteLine($"The task was not found");
            }
            else
            {
                service.TaskInfo(taskItem);
            }
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("All tasks");
            List<TaskItem> tasks = service.GetAllTasks();
            foreach (var t in tasks)
            {
                service.TaskInfo(t);
            }
            break;
        case "4":
            string choice;
            while (true)
            {
                Console.WriteLine("1. Ascending");
                Console.WriteLine("2. Descending");
                Console.Write("Enter sort option: ");
                choice = Console.ReadLine().Trim();
                if (choice == "1")
                {
                    service.SortTasksByDueDate();
                    break;
                }
                else if (choice == "2") 
                {
                    service.SortTasksByDueDate(false);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a valid option.");
                }
            }
            Console.Clear();
            Console.WriteLine("Successfully sorted...");
            break;
        case "5":
            Console.Write("Enter taskId: ");
            int taskItemId;
            while (!int.TryParse(Console.ReadLine().Trim(), out taskItemId) || taskItemId < 0)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id.");
                Console.Write("Enter taskId: ");
            }
            bool isRemoved = service.DeleteTask(taskItemId);
            Console.Clear();
            if (isRemoved)
            {
                Console.WriteLine("Successfully removed...");
            }
            else
            {
                Console.WriteLine("Task was not found...");
            }
            break;
    }
    Console.WriteLine();
}
