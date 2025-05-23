public class Member
{
    // --- Személyes adatok ---
    public string MemberId           { get; }
    public string Name               { get; set; }
    public string Address            { get; set; }
    public DateTime RegistrationDate { get; }

    // --- Tagsági díj-kezelés ---
    public DateTime MembershipExpiry { get; private set; }
    private const decimal DailyMembershipRate = 1.0m;

    public decimal MembershipFeeOwed
        => DateTime.Now > MembershipExpiry
           ? (DateTime.Now - MembershipExpiry).Days * DailyMembershipRate
           : 0m;

    // --- Könyvkölcsönzések nyilvántartása ---
    private readonly List<Loan> _activeLoans = new();
    public IReadOnlyList<Loan> ActiveLoans => _activeLoans;

    private readonly List<Loan> _loanHistory = new();
    public IReadOnlyList<Loan> LoanHistory => _loanHistory;

    // --- Segéd property-k a korlátozásokhoz ---
    public bool HasOverdueLoans
        => _activeLoans.Any(loan => loan.IsOverdue());

    public bool CanBorrow
        => _activeLoans.Sum(l => l.Books.Count) < 5
           && MembershipFeeOwed == 0m
           && !HasOverdueLoans;

    public bool HasOutstandingFines
        => _activeLoans.Any(l => l.OutstandingFine > 0m);

    // --- Konstruktor ---
    public Member(string memberId, string name, string address,
                  DateTime registrationDate, DateTime membershipExpiry)
    {
        MemberId           = memberId;
        Name               = name;
        Address            = address;
        RegistrationDate   = registrationDate;
        MembershipExpiry   = membershipExpiry;
    }

    // --- Tagság megújítása ---
    public void RenewMembership(DateTime newExpiry)
        => MembershipExpiry = newExpiry;

    // --- Könyvek kölcsönzése ---
    public void BorrowBooks(IEnumerable<Book> books, DateTime dueDate)
    {
        var bookList = books.ToList();
        if (!CanBorrow || _activeLoans.Sum(l => l.Books.Count) + bookList.Count > 5)
            throw new InvalidOperationException("Nem kölcsönözhet több könyvet.");

        var loan = new Loan(this, bookList, DateTime.Now, dueDate);
        _activeLoans.Add(loan);
    }

    // --- Részleges vagy teljes visszahozás ---
    public void ReturnBooks(Loan loan, IEnumerable<Book> booksToReturn, DateTime returnDate)
    {
        if (!_activeLoans.Contains(loan))
            throw new InvalidOperationException("Ez a kölcsönzés nem aktív ennél a tagnál.");

        foreach (var book in booksToReturn)
        {
            loan.RemoveBook(book);
        }

        // ha már egyáltalán nincs könyv a Loan-ban, lezárjuk
        if (loan.State == Loan.LoanState.Empty)
        {
            loan.MarkReturned();  
            _activeLoans.Remove(loan);
            _loanHistory.Add(loan);
        }
    }

    // --- Tagdíj befizetése ---
    public decimal PayMembershipFee(DateTime newExpiry)
    {
        var owed = MembershipFeeOwed;
        RenewMembership(newExpiry);
        return owed;
    }

    // --- Pótdíjak befizetése ---
    public decimal PayAllFines()
    {
        var total = _activeLoans.Sum(l => l.OutstandingFine);
        foreach (var loan in _activeLoans.Where(l => l.OutstandingFine > 0m))
            loan.PayFine();
        return total;
    }
}
