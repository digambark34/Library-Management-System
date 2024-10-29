# Library Management System

A simple console-based Library Management System written in C# to manage books and members. This project allows users to add books, register members, borrow books, return books, and view available books and members.

## Features

- **Add Books**: Add new books to the library collection.
- **Register Members**: Register new members who can borrow books.
- **Borrow Books**: Allows members to borrow available books.
- **Return Books**: Allows members to return borrowed books.
- **Display Available Books**: Shows all books currently available in the library.
- **Display Members**: Lists all registered members.

## Getting Started

These instructions will help you get a copy of the project up and running on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later recommended)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/library-management-system.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd library-management-system
    ```

3. **Build the project:**

    ```bash
    dotnet build
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

## Usage

1. When you run the application, you'll see a menu with options to:
    - Add a Book
    - Register a Member
    - Borrow a Book
    - Return a Book
    - Display Available Books
    - Display Members
    - Exit

2. Enter the number corresponding to your choice, then follow the on-screen prompts.

3. For example, to add a book, select option `1`, enter the book title, and it will be added to the library.

## Code Structure

- **Book Class**: Represents a book with `Id`, `Title`, and `IsAvailable` properties.
- **Member Class**: Represents a member with `Id`, `Name`, and `BorrowedBookId` properties.
- **Library Class**: Manages the collection of books and members, along with operations for adding, borrowing, and returning books.
- **Program Class**: Provides the main entry point with a console-based menu for interacting with the system.


