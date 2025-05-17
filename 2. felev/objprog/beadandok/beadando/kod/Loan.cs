public class Loan
{
    // --- Referenciák ---
    public Member   Borrower   { get; }
    public Book     Book       { get; }

    // --- Időpontok ---
    public DateTime LoanDate   { get; }
    public DateTime DueDate    { get; }
    public DateTime? ReturnDate{ get; private set; }

    // --- Pótdíj-kezelés ---
    public bool     FinePaid   { get; private set; }

    // --- Konstruktor ---
    public Loan(Member borrower, Book book, DateTime loanDate, DateTime dueDate)
    {
        Borrower = borrower ?? throw new ArgumentNullException(nameof(borrower));
        Book     = book     ?? throw new ArgumentNullException(nameof(book));
        LoanDate = loanDate;
        DueDate  = dueDate;
    }

    // --- Ellenőrzés, hogy lejárt-e ---
    public bool IsOverdue()
    {
        var effectiveReturn = ReturnDate ?? DateTime.Now;
        return effectiveReturn.Date > DueDate.Date;
    }

    // --- Lejárásig eltelt napok száma ---
    private int DaysOverdue()
    {
        var end = ReturnDate ?? DateTime.Now;
        var days = (end.Date - DueDate.Date).Days;
        return days > 0 ? days : 0;
    }

    // --- Pótdíj kiszámítása Strategy+Factory mintával ---
    public decimal CalculateFine()
    {
        int overdueDays = DaysOverdue();
        if (overdueDays == 0) return 0m;

        var genreStrat = FineMultiplierFactory.CreateGenreStrategy();
        var stockStrat = FineMultiplierFactory.CreateStockStrategy();

        var genreMul = genreStrat.GetMultiplier(Book.Genre);
        var stockMul = stockStrat.GetMultiplier(Book.CopyCount);

        return overdueDays * genreMul * stockMul;
    }

    // --- Visszahozás kezelése ---
    public void MarkReturned(DateTime returnDate)
    {
        if (ReturnDate != null)
            throw new InvalidOperationException("A könyvet már visszahozták.");
        ReturnDate = returnDate;
    }

    // --- Pótdíj befizetése ---
    public void MarkFinePaid()
    {
        if (!IsOverdue())
            throw new InvalidOperationException("Nincs késedelmi díj.");
        FinePaid = true;
    }

    public bool IsReturned => ReturnDate != null;
}
