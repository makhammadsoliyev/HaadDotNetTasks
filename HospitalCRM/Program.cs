using HospitalCRM;
using System.Text.RegularExpressions;

HospitalService hospitalService = new HospitalService();
string opt;
bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("1. Register patient.");
    Console.WriteLine("2. Update patient.");
    Console.WriteLine("3. Get patient.");
    Console.WriteLine("4. Get all patients.");
    Console.WriteLine("5. Delete patient.");
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

            Patient patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = birthDay,
                PhoneNumber = number
            };
            Console.Clear();
            hospitalService.CreatePatient(patient);
            break;
        case "2":
            Console.Write("Enter patient id: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Invalid patient id. Please enter a valid id.");
                Console.Write("Enter patient id: ");
            }

            Patient patient1 = hospitalService.GetPatient(id);
            if (patient1 == null)
            {
                Console.WriteLine("Patient was not found...");
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

                Patient newPatient = new Patient
                {
                    FirstName = newFirstName,
                    LastName = newLastName,
                    DateOfBirth = newBirthDay,
                    PhoneNumber = newNumber
                };
                Console.Clear();
                hospitalService.UpdatePatient(newPatient, id);
            }
            break;
        case "3":
            Console.Write("Enter patient id: ");
            int patientId;

            while (!int.TryParse(Console.ReadLine(), out patientId) || patientId < 0)
            {
                Console.WriteLine("Invalid patient id. Please enter a valid id.");
                Console.Write("Enter patient id: ");
            }
            Patient patient2 = hospitalService.GetPatient(patientId);
            Console.Clear();
            if (patient2 == null)
            {
                Console.WriteLine("Patient was not found...");
            }
            else
            {
                Console.WriteLine($"Id: {patient2.Id}, Name: {patient2.FirstName} {patient2.LastName}, Phone number: {patient2.PhoneNumber}");
            }
            break;
        case "4":
            List<Patient> patients = hospitalService.GetAllPatients();
            Console.WriteLine("All patients");
            foreach (var p in patients)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.FirstName} {p.LastName}, Phone number: {p.PhoneNumber}");
            }
            break;
        case "5":
            Console.Write("Enter patient id: ");
            int id1;

            while (!int.TryParse(Console.ReadLine(), out id1) || id1 < 0)
            {
                Console.WriteLine("Invalid patient id. Please enter a valid id.");
                Console.Write("Enter patient id: ");
            }

            bool isDeleted = hospitalService.DeletePatient(id1);
            Console.Clear();
            if (isDeleted)
            {
                Console.WriteLine("Successfully deleted...");
            }
            else
            {
                Console.WriteLine("Patient was not deleted...");
            }
            break;
        case "6":
            isTrue = false;
            Console.Clear();
            Console.WriteLine("GoodBye...");
            break;
    }
    Console.WriteLine();
}
