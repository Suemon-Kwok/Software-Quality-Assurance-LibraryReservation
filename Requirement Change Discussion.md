# Step 10: Managing Requirement Change

New rule: **REQ-LIB-05** — A member cannot reserve more than one book at the same time.

## Which class may need to change?
- `ReservationService` — `ReserveBook` would need a new check for whether the member
  already holds an active reservation before allowing another one.
- Possibly `Member` — if you want to track a member's current reservation(s) directly
  on the Member object (e.g. a list or a single "active reservation" reference), rather
  than tracking it externally.

## Which test cases need to be added?
- `ReserveBook_MemberAlreadyHasActiveReservation_ReturnsFailure`
- `ReserveBook_MemberWithNoActiveReservation_Succeeds`
- (optional) `ReserveBook_MemberReturnsBook_CanReserveAgain` — if a "return book" flow
  is added later

## What should be added to the RTM?
A new row:

| Requirement ID | Requirement Summary | Acceptance Criteria | Test Case | Status |
|---|---|---|---|---|
| REQ-LIB-05 | Member cannot reserve more than one book at a time | AC-05 (new — define it, e.g. "Given a member with an active reservation, when they attempt another reservation, then it fails") | ReserveBook_MemberAlreadyHasActiveReservation_ReturnsFailure | Not yet implemented |
