// STEP 6: Create the ReservationService Class
// File name in Visual Studio: ReservationService.cs
// Project: LibraryReservation
// After adding this, BUILD THE SOLUTION and fix any errors before moving on.

// Same namespace as Book, Member, and ReservationResult.
namespace LibraryReservation
{
    // This class holds the actual BUSINESS LOGIC of the system - the rules for
    // whether a reservation is allowed. Book, Member, and ReservationResult are
    // just data; this class is what DOES something with that data.
    public class ReservationService
    {
        // Public method that attempts to reserve a book for a member.
        // Takes a Book and a Member as input, and always returns a ReservationResult
        // (never throws an exception itself - failures are reported via the result).
        public ReservationResult ReserveBook(Book book, Member member)
        {
            // --- Guard clause 1: was a book even provided? ---
            // "book == null" checks if no Book object was passed in at all.
            if (book == null)
                // Exit immediately with a failed result and a clear explanation -
                // this satisfies REQ-LIB-04 (always return a clear message).
                return new ReservationResult(false, "Reservation failed: book details are required.");

            // --- Guard clause 2: was a member even provided? ---
            if (member == null)
                // Same pattern - fail fast with an explanatory message rather than crashing.
                return new ReservationResult(false, "Reservation failed: member details are required.");

            // --- Guard clause 3: is the book already taken? ---
            // Checks the book's own IsReserved flag (set inside the Book class).
            if (book.IsReserved)
                // $"..." is a C# "interpolated string" - {book.Title} is replaced with
                // the book's actual title value at runtime. Enforces REQ-LIB-03.
                return new ReservationResult(false, $"Reservation failed: '{book.Title}' is already reserved.");

            // If we reach this line, all three guard clauses passed:
            // book exists, member exists, and the book is available.
            // Call the Book's own method to flip its IsReserved flag to true.
            book.MarkAsReserved();

            // Build and return a SUCCESS result, with a message that includes
            // both the book title and the member's name via string interpolation.
            return new ReservationResult(true, $"Reservation successful: '{book.Title}' has been reserved for {member.FullName}.");
        }
    }
}