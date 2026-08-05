// STEP 5: Create the ReservationResult Class
// File name in Visual Studio: ReservationResult.cs
// Project: LibraryReservation

// Same namespace as Book, Member, and ReservationService so they can all
// reference each other freely.
namespace LibraryReservation
{
    // This class doesn't represent a "thing" in the library (like Book or Member) -
    // it's a simple DATA CARRIER used to report the outcome of a reservation attempt.
    // Because it just bundles data with no complex behaviour, this is called a DTO
    // (Data Transfer Object).
    public class ReservationResult
    {
        // Read-only flag: true if the reservation succeeded, false if it failed.
        // No "set;" - once created, a result can't be silently changed later.
        public bool Success { get; }

        // Read-only human-readable explanation of what happened
        // (e.g. "Reservation successful..." or "Reservation failed: ...").
        public string Message { get; }

        // Constructor - runs whenever someone writes "new ReservationResult(success, message)".
        // Unlike Book/Member, there's no validation here - Success and Message are
        // set internally by ReservationService, so the values are already trusted.
        public ReservationResult(bool success, string message)
        {
            // Store the outcome flag passed in from whoever created this result.
            Success = success;

            // Store the explanatory message passed in from whoever created this result.
            Message = message;
        }
    }
}