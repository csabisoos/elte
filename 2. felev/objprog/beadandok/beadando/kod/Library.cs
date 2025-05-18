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
        if (_allLoans.Any(l => l.Books.Any(b => b.ISBN == isbn) && !l.IsReturned))
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

        var books = isbns.Select(isbn =>
            _inventory.FirstOrDefault(b => b.ISBN == isbn)
            ?? throw new InvalidOperationException($"Nincs ilyen könyv ({isbn}).")
        ).ToList();

        member.BorrowBooks(books, dueDate);

        // Felvesszük az új Loan-t
        var newLoan = member.ActiveLoans.Last();
        _allLoans.Add(newLoan);
    }

    public void ReturnBooks(string memberId, IEnumerable<string> isbns, DateTime returnDate)
    {
        var member = _members.FirstOrDefault(m => m.MemberId == memberId)
                     ?? throw new InvalidOperationException("Nincs ilyen tag.");

        // Minden ISBN-hez megkeressük a Loan-t, és visszahozzuk a konkrét könyvet
        foreach (var isbn in isbns)
        {
            var loan = member.ActiveLoans
                .FirstOrDefault(l => l.Books.Any(b => b.ISBN == isbn))
                ?? throw new InvalidOperationException($"A könyv ({isbn}) nincs kölcsönözve ennél a tagnál.");

            var book = loan.Books.First(b => b.ISBN == isbn);
            member.ReturnBooks(loan, new[] { book }, returnDate);
        }
    }

    // --- Fizetések ---
    public decimal PayMembershipFee(string memberId, DateTime newExpiry)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        return m.PayMembershipFee(newExpiry);
    }

    public decimal PayFines(string memberId)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        return m.PayAllFines();
    }

    // --- Lekérdezések ---
    public bool IsMember(string memberId)
        => _members.Any(m => m.MemberId == memberId);

    public bool IsBookAvailable(string isbn)
        => _inventory.Any(b => b.ISBN == isbn)
           && !_allLoans.Any(l => l.Books.Any(b => b.ISBN == isbn) && !l.IsReturned);

    public decimal GetMemberDebt(string memberId)
    {
        var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                ?? throw new InvalidOperationException("Nincs ilyen tag.");
        return m.MembershipFeeOwed + m.ActiveLoans.Sum(l => l.OutstandingFine);
    }

    public IEnumerable<Book> FindBooksByTitle(string title)
        => _inventory.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Member> GetAllMembers() => _members.AsReadOnly();
    public IEnumerable<Book>   GetAllBooks()   => _inventory.AsReadOnly();
    public IEnumerable<Loan>   GetAllLoans()   => _allLoans.AsReadOnly();
}
