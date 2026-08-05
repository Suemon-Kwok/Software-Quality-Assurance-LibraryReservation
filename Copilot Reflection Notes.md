# Step 7: GitHub Copilot Reflection Notes

Open GitHub Copilot Chat in Visual Studio and use this prompt:

> Suggest MSTest unit tests for this C# library reservation system. Focus on testable
> requirements, acceptance criteria, edge cases, and clear expected results.

Fill in the sections below as you go (during the actual lab, since this needs your
real Copilot output):

Prompt used

Suggest MSTest unit tests for this C# library reservation system. Focus on testable requirements, acceptance criteria, edge cases, and clear expected results.

(Note: GitHub Copilot was not installable on the lab PC — permission denied — so Claude was used as the AI assistant instead, per lab discussion.) Actually did find GitHub Copilot in the end but Copilot isn't good so I used Claude instead.

One useful suggestion

Claude suggested MarkAsReserved_CalledTwice_ThrowsInvalidOperationException, a test that calls Book.MarkAsReserved() directly (rather than going through ReservationService) to isolate and confirm that guard clause on its own. This was useful because it adds unit-level coverage on the Book class itself, separate from the integration-style coverage the existing service tests already provide.

One suggestion you modified

Claude initially suggested a performance-style test (ReserveBook_Performance_CompletesQuickly) checking that reservations complete quickly. This didn't map to any stated requirement, so it was modified into Book_EmptyTitle_ThrowsException instead — a test that mirrors the existing empty-ID check but validates the title field, which is actually covered by Book's constructor logic.

One suggestion you rejected

Claude suggested ReserveBook_CaseInsensitiveMemberId_ReturnsSuccess, testing that member IDs like "M001" and "m001" should be treated as equivalent. This was rejected because none of REQ-LIB-01 through REQ-LIB-04 specify anything about case sensitivity — the suggestion assumed behaviour that was never part of the requirements.

Why human judgement was required

The AI can generate plausible-sounding test ideas, but it doesn't know which behaviours were actually specified in REQ-LIB-01–04 and AC-01–04 versus which just sound reasonable. Only checking each suggestion against the actual requirements document could confirm whether a test added real coverage (like the two kept/modified ones) or tested an assumption nobody asked for (like the rejected one).

