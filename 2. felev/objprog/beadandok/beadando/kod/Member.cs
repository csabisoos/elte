public class Member
{
    // --- Személyes adatok ---
    public string MemberId     { get; }   // igazolványszám, egyedi azonosító
    public string Name         { get; set; }
    public string Address      { get; set; }
    public DateTime RegistrationDate { get; }  // mikor iratkozott be

    // --- Tagsági díj-kezelés ---
    public DateTime MembershipExpiry { get; private set; }
    public decimal MembershipFeeOwed  // igazolja, hogy kell-e tagdíjat fizetnie
        => (DateTime.Now > MembershipExpiry) ? CalculateMembershipFee() : 0m;

    // --- Könyvkölcsönzések nyilvántartása ---
    public List<Loan> ActiveLoans { get; } = new();   // jelenleg nála lévő kölcsönzések
    public List<Loan> LoanHistory { get; } = new();   // lezárt (visszahozott) kölcsönzések

    // --- Segéd property-k a korlátozásokhoz ---
    public bool HasOverdueLoans
        => ActiveLoans.Any(loan => loan.IsOverdue());

    public bool CanBorrow
        => ActiveLoans.Count < 5
           && MembershipFeeOwed == 0m
           && !HasOverdueLoans;

    public bool HasOutstandingFines
        => ActiveLoans.Sum(loan => loan.CalculateFine()) > 0m;

    // --- Konstruktor ---
    public Member(string memberId, string name, string address, DateTime registrationDate, DateTime membershipExpiry)
    {
        MemberId           = memberId;
        Name               = name;
        Address            = address;
        RegistrationDate   = registrationDate;
        MembershipExpiry   = membershipExpiry;
    }

    // --- Példák a tagdíj számítására, kölcsönzésre és visszahozásra ---
    private decimal CalculateMembershipFee()
    {
        // (például napi díj * lejárt napok száma)
        var daysLate = (DateTime.Now - MembershipExpiry).Days;
        return daysLate * DailyMembershipRate;
    }

    public void RenewMembership(DateTime newExpiry)
        => MembershipExpiry = newExpiry;


    public void BorrowBooks(IEnumerable<Book> books, DateTime dueDate)
    {
        foreach (var book in books)
        {
            if (!CanBorrow)
                throw new InvalidOperationException("Nem kölcsönözhet több könyvet.");
            
            var loan = new Loan(this, book, DateTime.Now, dueDate);
            ActiveLoans.Add(loan);
        }
    }

    public void ReturnBooks(IEnumerable<Loan> loans, DateTime returnDate)
    {
        foreach (var loan in loans)
        {
            if (!ActiveLoans.Remove(loan))
                throw new InvalidOperationException($"A könyv ({loan.Book.ISBN}) nincs kölcsönözve ennél a tagnál.");
            loan.MarkReturned(returnDate);
            LoanHistory.Add(loan);
        }
    }

    private const decimal DailyMembershipRate = 1.0m;  // példaérték
}
