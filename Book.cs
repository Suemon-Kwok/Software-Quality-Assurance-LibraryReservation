// STEP 3: Create the Book Class
// File name in Visual Studio: Book.cs
// Project: LibraryReservation

// Declares the namespace "LibraryReservation" - groups all related classes
// (Book, Member, ReservationResult, ReservationService) under one name so
// they can reference each other without extra imports.
namespace LibraryReservation
{
    // "public" means this class can be used by other projects (like the test project).
    // "class Book" defines a blueprint for creating Book objects.
    public class Book
    {
        // Auto-property for the book's unique ID.
        // "get;" with no "set;" makes it READ-ONLY after construction -
        // once a Book is created, its Id can never be changed.
        public string Id { get; }

        // Same idea as Id - the book's title is read-only after creation.
        public string Title { get; }

        // "get; private set;" means anyone can READ IsReserved,
        // but only code INSIDE this class can CHANGE it
        // (this protects the reservation status from being set directly by outside code).
        public bool IsReserved { get; private set; }

        // The constructor - this code runs whenever someone writes "new Book(id, title)".
        // It takes the two required pieces of data as parameters.
        public Book(string id, string title)
        {
            // Validation check: IsNullOrWhiteSpace catches null, "", and " " (spaces only).
            if (string.IsNullOrWhiteSpace(id))
                // If the id is invalid, stop construction immediately and throw an error
                // with a clear message explaining what went wrong.
                throw new ArgumentException("Book ID is required.");

            // Same validation pattern, this time checking the title.
            if (string.IsNullOrWhiteSpace(title))
                // Reject invalid titles the same way, with their own clear message.
                throw new ArgumentException("Book title is required.");

            // If we reach this line, both id and title passed validation.
            // Assign the constructor parameter "id" to the read-only property "Id".
            Id = id;

            // Assign the constructor parameter "title" to the read-only property "Title".
            Title = title;

            // Every new book starts out NOT reserved.
            IsReserved = false;
        }

        // A method (behaviour) that changes the book's state to "reserved".
        // "void" means this method doesn't return a value - it just performs an action.
        public void MarkAsReserved()
        {
            // Guard clause: check if the book is already reserved BEFORE changing anything.
            if (IsReserved)
                // Prevent double-booking by throwing an error instead of silently
                // allowing a second reservation on the same book.
                throw new InvalidOperationException("Book is already reserved.");

            // Only reached if the book was available - flip the flag to true.
            IsReserved = true;
        }
    }
}