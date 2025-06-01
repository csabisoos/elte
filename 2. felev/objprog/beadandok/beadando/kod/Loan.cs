using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Models
{
    public class Loan
    {
        // A könyvek listája – a state-objektumok csak ezen keresztül módosítanak.
        private readonly List<Book> _books = new();
        internal int InternalBookCount => _books.Count;

        // Az aktuális állapot: EmptyState, IntermediateState vagy FullState.
        private ILoanState _currentState;
        public ILoanState CurrentState => _currentState;

        public Member Borrower   { get; }
        public DateTime LoanDate { get; }
        public DateTime DueDate  { get; }
        public DateTime? ReturnDate { get; internal set; }  // a RemoveBook állítja be

        public DateTime? FinePaymentDate { get; private set; }

        /// <summary>
        /// A konstruktor inicializálja a loan-t üres állapotra (0 könyv),
        /// majd az első könyvlistát is felveszi a _books-be a state használatával.
        /// </summary>
        public Loan(Member borrower, IEnumerable<Book> books, DateTime loanDate, DateTime dueDate)
        {
            Borrower = borrower ?? throw new ArgumentNullException(nameof(borrower));
            LoanDate = loanDate;
            DueDate  = dueDate < loanDate
                ? throw new ArgumentException("DueDate must be >= LoanDate", nameof(dueDate))
                : dueDate;

            // Kezdeti állapot: EmptyState
            _currentState = new EmptyState(this);

            var bookList = books?.ToList() ?? throw new ArgumentNullException(nameof(books));
            if (bookList.Count > 5)
                throw new ArgumentException("Maximum 5 könyv lehet egy kölcsönzésben.", nameof(books));

            // Minden könyvet a state-nek adjuk át, az internal metódusokkal együtt
            foreach (var book in bookList)
            {
                AddBook(book);
            }
        }

        /// <summary>
        /// Állapotfüggő hozzáadás (delegáljuk a _currentState AddBook(...) metódusának).
        /// </summary>
        public void AddBook(Book book)
        {
            _currentState.AddBook(book);
        }

        /// <summary>
        /// Állapotfüggő eltávolítás (delegáljuk a _currentState RemoveBook(...) metódusának).
        /// </summary>
        public void RemoveBook(Book book)
        {
            if (!_books.Remove(book))
                 throw new InvalidOperationException("Ez a könyv nem része ennek a kölcsönzésnek.");

            // Ha ez volt az utolsó könyv, állítsuk be a ReturnDate-et
            if (_books.Count == 0) ReturnDate = returnDate;
        }

        /// <summary>
        /// Ha a könyvlista üres, lezárjuk a kölcsönzést (ReturnDate beállítása).
        /// </summary>
        public void MarkReturned()
        {
            _currentState.CloseIfEmpty();
        }

        /// <summary>
        /// Az állapot gép belső állapot-átmenetét hívja.
        /// Csak a state-objektumok módosíthatják.
        /// </summary>
        internal void ChangeState(ILoanState newState)
        {
            _currentState = newState ?? throw new ArgumentNullException(nameof(newState));
        }

        #region Visitor‐alapú pótdíjszámítás (FineVisitor)

        public bool IsOverdue()
        {
            var end = ReturnDate ?? DateTime.Now;
            return end.Date > DueDate.Date;
        }

        public int DaysOverdue
            => Math.Max(0, ((ReturnDate ?? DateTime.Now).Date - DueDate.Date).Days);

        public decimal CalculateFine()
        {
            int days = DaysOverdue;
            if (days == 0) return 0m;

            decimal totalFine = 0m;
            foreach (var book in _books)
            {
                var visitor = new FineVisitor(days);
                book.Accept(visitor);
                totalFine += visitor.GetResult();
            }
            return totalFine;
        }

        public decimal OutstandingFine
            => IsOverdue() && FinePaymentDate == null
               ? CalculateFine()
               : 0m;

        public void PayFine()
        {
            if (OutstandingFine == 0m)
                throw new InvalidOperationException("Nincs fizetendő pótdíj.");
            FinePaymentDate = DateTime.Now;
        }

        #endregion

        #region Internal metódusok a State-nek

        /// <summary>
        /// Belső metódus: ténylegesen hozzáadjuk a könyvet a listához.
        /// A _currentState csak ezen keresztül módosíthatja.
        /// </summary>
        /// <param name="book">A hozzáadni kívánt könyv.</param>
        internal void Internal_AddToBooks(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            _books.Add(book);
        }

        /// <summary>
        /// Belső metódus: ténylegesen eltávolítjuk a könyvet a listából.
        /// A _currentState csak ezen keresztül módosíthatja.
        /// Visszaadja, hogy sikerült-e (true), vagy nem találtuk (false).
        /// </summary>
        /// <param name="book">A visszahozott könyv.</param>
        internal bool Internal_RemoveFromBooks(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            return _books.Remove(book);
        }

        #endregion

        public bool IsReturned => ReturnDate.HasValue;

    }
}
