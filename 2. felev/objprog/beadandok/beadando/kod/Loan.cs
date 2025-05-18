public class Loan
{
    private readonly List<Book> _books = new();
    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public Member Borrower { get; }
    public DateTime LoanDate { get; }
    public DateTime DueDate  { get; }
    public DateTime? ReturnDate { get; private set; }

    // State-kezelés: 0, 1–4, 5 könyv
    public LoanState State
        => _books.Count == 0 ? LoanState.Empty
         : _books.Count < 5 ? LoanState.PartialFull
         : LoanState.Full;

    // Konstruktor: egyszerre kapja a könyveket
    public Loan(Member borrower, IEnumerable<Book> books, DateTime loanDate, DateTime dueDate)
    {
        Borrower = borrower ?? throw new ArgumentNullException(nameof(borrower));
        LoanDate = loanDate;
        DueDate  = dueDate < loanDate
            ? throw new ArgumentException("DueDate must be >= LoanDate", nameof(dueDate))
            : dueDate;

        var bookList = books?.ToList() ?? throw new ArgumentNullException(nameof(books));
        if (bookList.Count > 5)
            throw new ArgumentException("Maximum 5 könyv lehet egy kölcsönzésben.", nameof(books));

        foreach (var book in bookList)
            _books.Add(book);
    }

    // Könyv eltávolítása (részleges visszahozás)
    public void RemoveBook(Book book)
    {
        if (!_books.Remove(book))
            throw new InvalidOperationException("Ez a könyv nem része ennek a kölcsönzésnek.");

        if (_books.Count == 0)
            ReturnDate = DateTime.Now;  // az utolsó visszahozás automatikusan lezárja
    }

    // Visszatérés státusza
    public bool IsReturned => ReturnDate.HasValue;

    // Lejárat-ellenőrzés
    public bool IsOverdue()
    {
        var end = ReturnDate ?? DateTime.Now;
        return end.Date > DueDate.Date;
    }

    public int DaysOverdue
        => Math.Max(0, ((ReturnDate ?? DateTime.Now).Date - DueDate.Date).Days);

    // Pótdíj-számítás (Strategy + Factory)
    public decimal CalculateFine()
    {
        int days = DaysOverdue;
        if (days == 0) return 0m;

        var calc = FineCalculatorFactory.Create();
        return _books.Sum(book => days * calc.GetDailyFine(book.Genre, book.CopyCount));
    }

    // Teljes lezárás (ha minden visszahozva)
    public void MarkReturned()
    {
        if (_books.Count != 0)
            throw new InvalidOperationException("Minden könyvet előbb vissza kell hozni.");
        // ReturnDate már beállítódott a RemoveBook-ban
    }

    // Pótdíj fizetése
    public DateTime? FinePaymentDate { get; private set; }
    public decimal   OutstandingFine
        => IsOverdue() && FinePaymentDate == null ? CalculateFine() : 0m;

    public void PayFine()
    {
        if (OutstandingFine == 0m)
            throw new InvalidOperationException("Nincs fizetendő pótdíj.");
        FinePaymentDate = DateTime.Now;
    }
}
