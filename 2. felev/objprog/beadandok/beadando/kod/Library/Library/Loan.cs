namespace Library
{
    public class Loan
    {
        private decimal _cachedFine = -1m;
        private readonly List<Book> _returnedBooksBeforeRemoval = new();

        // A könyvek listája – a state-objektumok csak ezen keresztül módosítanak.
        private readonly List<Book> _books = new();
        public List<Book> Books => _books;
        internal int InternalBookCount => _books.Count;

        // Az aktuális állapot: EmptyState, IntermediateState vagy FullState.
        private ILoanState _currentState;
        public ILoanState CurrentState => _currentState;

        public Member Borrower    { get; }
        public DateTime LoanDate  { get; set; }
        public DateTime DueDate   { get; }
        public DateTime? ReturnDate { get; internal set; }  // a RemoveBook állítja be

        public DateTime? FinePaymentDate { get; private set; }

        /// <summary>
        /// Konstruktor: kezdetben üres állapotba állítja a Loan-t, majd
        /// a kapott könyveket AddBook() hívással veszi fel.
        /// </summary>
        public Loan(Member borrower, IEnumerable<Book> books, DateTime? loanDate, DateTime dueDate)
        {
            Borrower = borrower ?? throw new ArgumentNullException(nameof(borrower));
            LoanDate = loanDate ?? DateTime.Now;
            DueDate  = dueDate < loanDate
                ? throw new ArgumentException("DueDate must be >= LoanDate", nameof(dueDate))
                : dueDate;

            // Kezdeti állapot: EmptyState
            _currentState = new EmptyState(this);

            var bookList = books?.ToList() ?? throw new ArgumentNullException(nameof(books));
            if (bookList.Count > 5)
                throw new ArgumentException("Maximum 5 könyv lehet egy kölcsönzésben.", nameof(books));

            // Minden könyvet a state-nek adjuk át, amely belsőleg hívja Internal_AddToBooks-t
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
            _currentState.RemoveBook(book);
        }

        /// <summary>
        /// Ha a könyvlista üres, lezárjuk a kölcsönzést (ReturnDate beállítása).
        /// </summary>
        public void MarkReturned()
        {
            _currentState.CloseIfEmpty();
        }

        /// <summary>
        /// Állapotváltást végző belső metódus; csak a state-objektumok hívhatják.
        /// </summary>
        internal void ChangeState(ILoanState newState)
        {
            _currentState = newState ?? throw new ArgumentNullException(nameof(newState));
        }

        /// <summary>
        /// Megadja, hogy a kölcsönzés teljesen vissza lett-e hozva.
        /// </summary>
        public bool IsReturned => ReturnDate.HasValue;

        #region Visitor‐alapú pótdíjszámítás (FineVisitor)

        /// <summary>
        /// Ellenőrzi, hogy jelenleg (ReturnDate vagy most) túl van-e a DueDate-en.
        /// </summary>
        public bool IsOverdue()
        {
            var end = ReturnDate ?? DateTime.Now;
            return end.Date > DueDate.Date;
        }
        
        public void RemoveBook(Book book, DateTime returnDate)
        {
            if (!_books.Remove(book))
                throw new InvalidOperationException("Ez a könyv nem része ennek a kölcsönzésnek.");

            if (_books.Count == 0)
            {
                // Mivel ez az utolsó könyv, számoljuk ki a pótdíjat a teljes listára
                _cachedFine = 0m;
                int days = DaysOverdue;
                if (days > 0)
                {
                    foreach (var b in _returnedBooksBeforeRemoval) // lásd lent
                    {
                        var visitor = new FineVisitor(days);
                        b.Accept(visitor);
                        _cachedFine += visitor.GetResult();
                    }
                }

                ReturnDate = returnDate;
            }
        }

        /// <summary>
        /// Hány napja van késésben (ha negatív lenne, 0-t ad vissza).
        /// </summary>
        public int DaysOverdue
            => Math.Max(0, ((ReturnDate ?? DateTime.Now).Date - DueDate.Date).Days);

        /// <summary>
        /// Pótdíj-számítás Visitor-mintával: minden egyes könyvet meghívjuk:
        ///   var visitor = new FineVisitor(daysOverdue);
        ///   book.Accept(visitor);
        ///   totalFine += visitor.GetResult();
        /// </summary>
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

        /// <summary>
        /// Aktuális tartozás: csak akkor, ha túl van a DueDate-en és még nem fizették be.
        /// </summary>
        public decimal OutstandingFine
            => IsOverdue() && FinePaymentDate == null
               ? CalculateFine()
               : 0m;

        /// <summary>
        /// A pótdíj befizetése: beállítja a FinePaymentDate-et, 
        /// de csak akkor, ha tényleg van befizetendő díj.
        /// </summary>
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
        internal void Internal_RemoveFromBooks(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            bool removed = _books.Remove(book);
            if (removed)
                _returnedBooksBeforeRemoval.Add(book);
        }

        #endregion
    }
}

