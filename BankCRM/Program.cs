using BankCRM.BankService;
using BankCRM.Entities;
using BankCRM.Interfaces;
using System.Text.RegularExpressions;

IBankService bankService = new BankService();
string opt;
bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("1. Register client.");
    Console.WriteLine("2. Update client.");
    Console.WriteLine("3. Get client.");
    Console.WriteLine("4. Get all clients.");
    Console.WriteLine("5. Delete client.");
    Console.WriteLine("6. Exit.");
    Console.Write("Enter your option[1-6]: ");

    opt = Console.ReadLine();
    Console.Clear();

    switch (opt)
    {
        case "1":
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Invalid name. Please enter a valid name.");
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Invalid name. Please enter a valid name.");
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
            }

            Console.Write("Enter date of birth(dd/mm/yyyy): ");
            DateOnly birthDay;
            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out birthDay))
            {
                Console.WriteLine("Invalid birth day. Please enter a valid day");
                Console.Write("Enter date of birth(dd/mm/yyyy): ");
            }

            string format = @"^\+998\d{9}$";
            Console.Write("Enter phone number(+998XXxxxxxxx): ");
            string number = Console.ReadLine();

            while (!Regex.IsMatch(number, format))
            {
                Console.WriteLine("Invalid number. Please enter a valid number.");
                Console.Write("Enter phone number(+998XXxxxxxxx): ");
                number = Console.ReadLine();
            }

            Client client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = birthDay,
                PhoneNumber = number
            };
            Console.Clear();
            bankService.CreateClient(client);
            break;
        case "2":
            Console.Write("Enter client id: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Invalid client id. Please enter a valid id.");
                Console.Write("Enter client id: ");
            }
            Client patient1 = bankService.GetClient(id);
            if (patient1 == null)
            {
                Console.WriteLine("Client was not found...");
            }
            else
            {
                Console.Write("Enter first name: ");
                string newFirstName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newFirstName))
                {
                    Console.WriteLine("Invalid name. Please enter a valid name.");
                    Console.Write("Enter first name: ");
                    newFirstName = Console.ReadLine();
                }

                Console.Write("Enter last name: ");
                string newLastName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newLastName))
                {
                    Console.WriteLine("Invalid name. Please enter a valid name.");
                    Console.Write("Enter last name: ");
                    newLastName = Console.ReadLine();
                }

                Console.Write("Enter date of birth(dd/mm/yyyy): ");
                DateOnly newBirthDay;
                while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out newBirthDay))
                {
                    Console.WriteLine("Invalid birth day. Please enter a valid day");
                    Console.Write("Enter date of birth(dd/mm/yyyy): ");
                }

                Console.Write("Enter phone number(+998XXxxxxxxx): ");
                string newNumber = Console.ReadLine();
                string newFormat = @"^\+998\d{9}$";

                while (!Regex.IsMatch(newNumber, newFormat))
                {
                    Console.WriteLine("Invalid number. Please enter a valid number.");
                    Console.Write("Enter phone number(+998XXxxxxxxx): ");
                    newNumber = Console.ReadLine();
                }

                Client newClient = new Client
                {
                    FirstName = newFirstName,
                    LastName = newLastName,
                    DateOfBirth = newBirthDay,
                    PhoneNumber = newNumber
                };
                Console.Clear();
                bankService.UpdateClient(newClient, id);
            }
            break;
        case "3":
            Console.Write("Enter client id: ");
            int clientId;

            while (!int.TryParse(Console.ReadLine(), out clientId) || clientId < 0)
            {
                Console.WriteLine("Invalid client id. Please enter a valid id.");
                Console.Write("Enter client id: ");
            }

            Client client12 = bankService.GetClient(clientId);
            Console.Clear();
            if (client12 == null)
            {
                Console.WriteLine("Client was not found...");
            }
            else
            {
                Console.WriteLine($"Id: {client12.Id}, Name: {client12.FirstName} {client12.LastName}, Phone number: {client12.PhoneNumber}");
            }
            break;
        case "4":
            List<Client> clients = bankService.GetAllClients();
            Console.WriteLine("All clients...");
            foreach (var c in clients)
            {
                Console.WriteLine($"Id: {c.Id}, Name: {c.FirstName} {c.LastName}, Phone number: {c.PhoneNumber}");
            }
            break;
        case "5":
            Console.Write("Enter client id: ");
            int id1;

            while (!int.TryParse(Console.ReadLine(), out id1) || id1 < 0)
            {
                Console.WriteLine("Invalid client id. Please enter a valid id.");
                Console.Write("Enter client id: ");
            }

            bool isDeleted = bankService.DeleteClient(id1);
            Console.Clear();
            if (isDeleted)
            {
                Console.WriteLine("Successfully deleted...");
            }
            else
            {
                Console.WriteLine("Client was not deleted...");
            }
            break;
        case "6":
            isTrue = false;
            Console.Clear();
            Console.WriteLine("GoodBye...");
            break;
            break;
    }


}
