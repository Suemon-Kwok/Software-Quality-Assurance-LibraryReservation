// STEP 4: Create the Member Class
// File name in Visual Studio: Member.cs
// Project: LibraryReservation

// Same namespace as Book, ReservationResult, and ReservationService,
// so all these classes can see and use each other without extra imports.
namespace LibraryReservation
{
    // "public" so the test project and other classes can create Members.
    // "class Member" is the blueprint for a library member.
    public class Member
    {
        // Auto-property for the member's unique ID.
        // Read-only (get; only, no set;) - once set in the constructor,
        // it can never be changed again.
        public string Id { get; }

        // Same pattern for the member's full name - read-only after creation.
        public string FullName { get; }

        // Constructor - runs whenever someone writes "new Member(id, fullName)".
        public Member(string id, string fullName)
        {
            // Reject a missing/blank ID before doing anything else.
            // IsNullOrWhiteSpace catches null, "", and strings that are just spaces.
            if (string.IsNullOrWhiteSpace(id))
                // Stop construction and report exactly what's wrong.
                throw new ArgumentException("Member ID is required.");

            // Same validation check, this time for the name field.
            if (string.IsNullOrWhiteSpace(fullName))
                // Stop construction with a clear, specific error message.
                throw new ArgumentException("Member name is required.");

            // Both checks passed - safe to assign the parameter to the read-only property.
            Id = id;

            // Assign the validated name to the read-only FullName property.
            FullName = fullName;
        }
    }
}