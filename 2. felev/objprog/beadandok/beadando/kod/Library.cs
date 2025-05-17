public class Library
{
    // --- Adattagok ---
    private readonly List<Book> _inventory = new();
    private readonly List<Member> _members = new();
    private readonly List<Loan> _allLoans = new();

    // --- Könyvkezelés ---
    public void AddBook(Book book)
    {
        if (_inventory.Any(b => b.ISBN == book.ISBN))
            throw new InvalidOperationException("Ez az ISBN már szerepel az állományban.");
        _inventory.Add(book);
    }

    public void RemoveBook(string isbn)
    {
        var book = _inventory.FirstOrDefault(b => b.ISBN == isbn)
                   ?? throw new InvalidOperationException("Nincs ilyen könyv az állományban.");
        if (_allLoans.Any(l => l.Book.ISBN == isbn && !l.IsReturned))
            throw new InvalidOperationException("A könyv jelenleg ki van kölcsönözve.");
        _inventory.Remove(book);
    }

    // --- Tagságkezelés ---
    public void RegisterMember(Member member)
    {
        if (_members.Any(m => m.MemberId == member.MemberId))
            throw new InvalidOperationException("Ez a tag már létezik.");
        _members.Add(member);
    }

    public void DeregisterMember(string memberId)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        if (m.ActiveLoans.Any() || m.HasOutstandingFines)
            throw new InvalidOperationException("A tagnak vannak fennálló kölcsönzései vagy tartozásai.");
        _members.Remove(m);
    }

    // --- Kölcsönzés és visszahozás ---
    public void BorrowBooks(string memberId, IEnumerable<string> isbns, DateTime dueDate)
    {
        var member = _members.FirstOrDefault(m => m.MemberId == memberId)
                     ?? throw new InvalidOperationException("Nincs ilyen tag.");

        // lekérdezzük a Book objektumokat az ISBN-ek alapján
        var books = isbns.Select(isbn =>
            _inventory.FirstOrDefault(b => b.ISBN == isbn)
            ?? throw new InvalidOperationException($"Nincs ilyen könyv ({isbn}).")
        ).ToList();

        // delegáljuk a Member-nek
        member.BorrowBooks(books, dueDate);

        // minden új Loan hozzáadása az _allLoans gyűjteményhez
        foreach (var loan in member.ActiveLoans.Where(l => !_allLoans.Contains(l)))
            _allLoans.Add(loan);
    }

    // Tömeges visszahozás
    public void ReturnBooks(string memberId, IEnumerable<string> isbns, DateTime returnDate)
    {
        var member = _members.FirstOrDefault(m => m.MemberId == memberId)
                     ?? throw new InvalidOperationException("Nincs ilyen tag.");

        // megkeressük az adott tag ActiveLoans-ában azokat a Loan-okat, amik ISBN-re egyeznek
        var loansToReturn = member.ActiveLoans
            .Where(l => isbns.Contains(l.Book.ISBN))
            .ToList();

        if (loansToReturn.Count != isbns.Count())
            throw new InvalidOperationException("Néhány könyv nincs kölcsönözve ennél a tagnál.");

        // delegáljuk a Member-nek a visszahozást
        member.ReturnBooks(loansToReturn, returnDate);
    }


    // --- Fizetések ---
    public decimal PayMembershipFee(string memberId, DateTime newExpiry)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        decimal owed = m.MembershipFeeOwed;
        m.RenewMembership(newExpiry);
        return owed;
    }

    public decimal PayFines(string memberId)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        decimal totalFine = m.ActiveLoans.Sum(l => l.CalculateFine());
        // itt feltételezheted, hogy befizetés után nullázod:
        foreach (var loan in m.ActiveLoans)
            loan.MarkFinePaid();
        return totalFine;
    }

    // --- Lekérdezések ---
    public bool IsMember(string memberId)
        => _members.Any(m => m.MemberId == memberId);

    public bool IsBookAvailable(string title)
        => _inventory.Any(b => b.Title == title)
           && !_allLoans.Any(l => l.Book.Title == title && !l.IsReturned);

    public decimal GetMemberDebt(string memberId)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        return m.MembershipFeeOwed + m.ActiveLoans.Sum(l => l.CalculateFine());
    }

    public IEnumerable<Book> FindBooksByTitle(string title)
        => _inventory.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Member> GetAllMembers() => _members.AsReadOnly();
    public IEnumerable<Book>   GetAllBooks()   => _inventory.AsReadOnly();
    public IEnumerable<Loan>   GetAllLoans()   => _allLoans.AsReadOnly();
}
