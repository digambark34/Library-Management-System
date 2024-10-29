using System;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public class Member
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int BorrowedBookId { get; set; } = -1;
}

public class Library
{
    private Book[] books;
    private Member[] members;
    private int bookCount = 0;
    private int memberCount = 0;

    public Library(int maxBook, int maxMember)
    {
        books = new Book[maxBook];
        members = new Member[maxMember];
    }

    public void AddBook(string title)
    {
        if (bookCount < books.Length)
        {
            books[bookCount] = new Book { Id = bookCount + 1, Title = title };
            Console.WriteLine($"Book {title} added with Id {books[bookCount].Id}");
            bookCount++;
        }
        else
        {
            Console.WriteLine("Library full, cannot add more books.");
        }
    }

    public void RegisterMember(string name)
    {
        if (memberCount < members.Length)
        {
            members[memberCount] = new Member { Id = memberCount + 1, Name = name };
            Console.WriteLine($"Member {name} registered with id {members[memberCount].Id}");
            memberCount++;
        }
        else
        {
            Console.WriteLine("Library has reached max members.");
        }
    }

    public void BorrowBook(int memberId, int bookId)
    {
        Member member = FindMemberById(memberId);
        Book book = FindBookById(bookId);
        if (member == null || book == null || !book.IsAvailable)
        {
            Console.WriteLine("Unable to borrow book.");
            return;
        }
        member.BorrowedBookId = bookId;
        book.IsAvailable = false;
        Console.WriteLine($"{book.Title} borrowed by {member.Name}");
    }

    public void ReturnBook(int memberId)
    {
        Member member = FindMemberById(memberId);
        if (member == null || member.BorrowedBookId == -1)
        {
            Console.WriteLine("No borrowed book to return.");
            return;
        }
        Book book = FindBookById(member.BorrowedBookId);
        book.IsAvailable = true;
        member.BorrowedBookId = -1;
        Console.WriteLine($"{book.Title} returned by {member.Name}");
    }

    public void DisplayAvailableBooks()
    {
        Console.WriteLine("Available Books:");
        foreach (var book in books)
        {
            if (book != null && book.IsAvailable)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
            }
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("Library Members:");
        foreach (var member in members)
        {
            if (member != null)
            {
                Console.WriteLine($"ID: {member.Id}, Name: {member.Name}");
            }
        }
    }

    private Book FindBookById(int bookId)
    {
        foreach (var book in books)
        {
            if (book != null && book.Id == bookId)
            {
                return book;
            }
        }
        return null;
    }

    private Member FindMemberById(int memberId)
    {
        foreach (var member in members)
        {
            if (member != null && member.Id == memberId)
            {
                return member;
            }
        }
        return null;
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library(500, 200);
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Register Member");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Display Available Books");
            Console.WriteLine("6. Display Members");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Select an Option:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Book Title:");
                    string bookTitle = Console.ReadLine();
                    library.AddBook(bookTitle);
                    break;

                case "2":
                    Console.WriteLine("Enter Member Name:");
                    string memberName = Console.ReadLine();
                    library.RegisterMember(memberName);
                    break;

                case "3":
                    Console.WriteLine("Enter Member ID:");
                    int memberBorrow = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Book ID:");
                    int bookBorrow = int.Parse(Console.ReadLine());
                    library.BorrowBook(memberBorrow, bookBorrow);
                    break;

                case "4":
                    Console.WriteLine("Enter Member ID to return book:");
                    int memberIdReturn = int.Parse(Console.ReadLine());
                    library.ReturnBook(memberIdReturn);
                    break;

                case "5":
                    library.DisplayAvailableBooks();
                    break;

                case "6":
                    library.DisplayMembers();
                    break;

                case "7":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again................");
                    break;
            }
        }
    }
}
