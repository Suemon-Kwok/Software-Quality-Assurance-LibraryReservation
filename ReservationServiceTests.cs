// STEP 8: Create Reservation Tests
// File name in Visual Studio: ReservationServiceTests.cs
// Project: LibraryReservation.Tests

// MSTest's testing framework - gives us [TestClass], [TestMethod], and Assert.
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Brings in Book, Member, ReservationResult, and ReservationService from the
// main project, so this test project can create and use them.
using LibraryReservation;

// This test project has its own namespace, separate from the main project,
// even though it references the LibraryReservation classes.
namespace LibraryReservation.Tests
{
    // [TestClass] tells MSTest "this class contains tests to run".
    // Without this attribute, MSTest would ignore everything inside.
    [TestClass]
    public class ReservationServiceTests
    {
        // [TestMethod] marks this specific method as a runnable test.
        // Test names follow the pattern: MethodUnderTest_Scenario_ExpectedResult.
        [TestMethod]
        public void ReserveBook_AvailableBookAndValidMember_ReturnsSuccess()
        {
            // ARRANGE: set up a fresh available book for this test.
            var book = new Book("B001", "Software Testing Basics");
            // ARRANGE: set up a valid member.
            var member = new Member("M001", "Aroha Smith");
            // ARRANGE: set up the service under test.
            var service = new ReservationService();

            // ACT: call the method being tested and capture its result.
            ReservationResult result = service.ReserveBook(book, member);

            // ASSERT: the reservation should have succeeded (covers AC-01).
            Assert.IsTrue(result.Success);
            // ASSERT: the message should confirm success in plain language (covers REQ-LIB-04).
            StringAssert.Contains(result.Message, "Reservation successful");
        }

        [TestMethod]
        public void ReserveBook_AvailableBook_MarksBookAsReserved()
        {
            // ARRANGE: same setup as above - available book, valid member.
            var book = new Book("B001", "Software Testing Basics");
            var member = new Member("M001", "Aroha Smith");
            var service = new ReservationService();

            // ACT: reserve the book. Note the return value isn't captured here -
            // this test cares about a SIDE EFFECT, not the returned result.
            service.ReserveBook(book, member);

            // ASSERT: check that the book object's own state actually changed
            // (i.e. MarkAsReserved() really ran) - this is a different check
            // from the previous test, which only checked the RESULT object.
            Assert.IsTrue(book.IsReserved);
        }

        [TestMethod]
        public void Member_EmptyMemberId_ThrowsException()
        {
            // This test targets the Member class directly, not ReservationService,
            // to confirm its own constructor validation works in isolation.
            // Assert.ThrowsExactly wraps a lambda (() => ...) - the code inside
            // only runs when MSTest checks whether it throws the given exception type.
            // (Note: older MSTest versions/tutorials use Assert.ThrowsException, but
            // that method was removed in MSTest 4 - ThrowsExactly is its replacement.)
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Member("", "Aroha Smith"));
        }

        [TestMethod]
        public void ReserveBook_AlreadyReservedBook_ReturnsFailure()
        {
            // ARRANGE: one book...
            var book = new Book("B001", "Software Testing Basics");
            // ARRANGE: ...and TWO different members, to simulate a second person
            // trying to reserve a book someone else already has.
            var member1 = new Member("M001", "Aroha Smith");
            var member2 = new Member("M002", "John Chen");
            var service = new ReservationService();

            // ACT: member1 reserves the book first (this call's result is ignored -
            // it's just setup to put the book into a "reserved" state).
            service.ReserveBook(book, member1);
            // ACT: member2 then tries to reserve the SAME already-reserved book.
            ReservationResult result = service.ReserveBook(book, member2);

            // ASSERT: the second attempt should fail (covers AC-03/REQ-LIB-03).
            Assert.IsFalse(result.Success);
            // ASSERT: the failure message should clearly explain why.
            StringAssert.Contains(result.Message, "already reserved");
        }

        [TestMethod]
        public void ReserveBook_NullBook_ReturnsClearFailureMessage()
        {
            // ARRANGE: a valid member, but deliberately no book object at all.
            var member = new Member("M001", "Aroha Smith");
            var service = new ReservationService();

            // ACT: pass null in place of a Book to trigger the service's first guard clause.
            ReservationResult result = service.ReserveBook(null, member);

            // ASSERT: the service should fail gracefully instead of crashing.
            Assert.IsFalse(result.Success);
            // ASSERT: the message should specifically mention the missing book.
            StringAssert.Contains(result.Message, "book details are required");
        }

        [TestMethod]
        public void ReserveBook_NullMember_ReturnsClearFailureMessage()
        {
            // ARRANGE: a valid book, but deliberately no member object at all.
            var book = new Book("B001", "Software Testing Basics");
            var service = new ReservationService();

            // ACT: pass null in place of a Member to trigger the service's second guard clause.
            ReservationResult result = service.ReserveBook(book, null);

            // ASSERT: the service should fail gracefully instead of crashing.
            Assert.IsFalse(result.Success);
            // ASSERT: the message should specifically mention the missing member.
            StringAssert.Contains(result.Message, "member details are required");
        }
    }
}

// Run all tests and confirm that they pass.