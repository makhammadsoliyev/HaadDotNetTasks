using LibrarySystem;

Library library = new Library();
string opt;


bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("1. Add book");
    Console.WriteLine("2. Display all books");
    Console.WriteLine("3. Search book.");
    Console.WriteLine("4. Sort books by Publication Year.");
    Console.WriteLine("5. Exit.");
    Console.Write("Enter your option[1-6]: ");

    opt = Console.ReadLine();
    Console.Clear();
    switch (opt)
    {
        case "1":
            Console.Write("Enter book id: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Invalid book id. Please enter a valid id.");
                Console.Write("Enter book id: ");
            }

            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Invalid book title. Please enter a valid title.");
                Console.Write("Enter book title: ");
                title = Console.ReadLine();
            }

            Console.Write("Enter author id: ");
            int authorId;

            while (!int.TryParse(Console.ReadLine(), out authorId) || authorId < 0)
            {
                Console.WriteLine("Invalid author id. Please enter a valid id.");
                Console.Write("Enter author id: ");
            }

            Console.Write("Enter book author name: ");
            string authorName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(authorName))
            {
                Console.WriteLine("Invalid book author name. Please enter a valid author name.");
                Console.Write("Enter book author name: ");
                authorName = Console.ReadLine();
            }

            Console.Write("Enter book author biography: ");
            string biography = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(biography))
            {
                Console.WriteLine("Invalid book author biography. Please enter a valid author biography.");
                Console.Write("Enter book author biography: ");
                biography = Console.ReadLine();
            }

            Author author = new Author
            {
                AuthorId = authorId,
                Name = authorName,
                Biography = biography
            };

            Console.Write("Enter book publicationYear: ");
            int publicationYear;

            while (!int.TryParse(Console.ReadLine(), out publicationYear) || publicationYear < 0)
            {
                Console.WriteLine("Invalid book publicationYear. Please enter a valid year.");
                Console.Write("Enter book publicationYear: ");
            }

            Book book = new Book
            {
                BookId = id,
                Title = title,
                Author = author,
                PublicationYear = publicationYear
            };
            library.AddBook(book);
            break;
        case "2":
            library.DisplayAllBooks();
            break;
        case "3":
            Console.Write("Enter book title: ");
            string bookTitle = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(bookTitle))
            {
                Console.WriteLine("Invalid book title. Please enter a valid title.");
                Console.Write("Enter book title: ");
                bookTitle = Console.ReadLine();
            }
            library.SearchByTitle(bookTitle);
            break;
        case "4":
            library.Sort(library.Books);
            break;
        case "5":
            isTrue = false;
            Console.WriteLine("GoodBye...");
            break;
    }
    Console.WriteLine();
}