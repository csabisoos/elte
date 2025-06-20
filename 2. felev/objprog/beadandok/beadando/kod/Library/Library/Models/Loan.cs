using Library.Books;
using Library.LoanStates;
using Library.Visitors;

namespace Library.Models
{
    public class Loan
    {
        private readonly List<Book> _books = new();
        public List<Book> Books => _books;
        internal int InternalBookCount => _books.Count;
        
        private ILoanState _currentState;
        public ILoanState CurrentState => _currentState;

        public Member Borrower    { get; }
        public DateTime LoanDate  { get; set; }
        public DateTime DueDate   { get; }
        public DateTime? ReturnDate { get; internal set; }  

        public DateTime? FinePaymentDate { get; private set; }
        
        public Loan(Member borrower, IEnumerable<Book> books, DateTime? loanDate, DateTime dueDate)
        {
            Borrower = borrower ?? throw new ArgumentNullException(nameof(borrower));
            LoanDate = loanDate ?? DateTime.Now;
            DueDate  = dueDate < loanDate
                ? throw new ArgumentException("DueDate must be >= LoanDate", nameof(dueDate))
                : dueDate;
            
            _currentState = new EmptyState(this);

            var bookList = books?.ToList() ?? throw new ArgumentNullException(nameof(books));
            if (bookList.Count > 5)
                throw new ArgumentException("Maximum 5 könyv lehet egy kölcsönzésben.", nameof(books));
            
            foreach (var book in bookList)
            {
                AddBook(book);
            }
        }
        
        public void AddBook(Book book)
        {
            _currentState.AddBook(book);
        }
        
        public void RemoveBook(Book book)
        {
            _currentState.RemoveBook(book);
        }
        
        public void MarkReturned()
        {
            _currentState.CloseIfEmpty();
        }
        
        internal void ChangeState(ILoanState newState)
        {
            _currentState = newState ?? throw new ArgumentNullException(nameof(newState));
        }
        
        public bool IsReturned => ReturnDate.HasValue;

        #region Visitor‐alapú pótdíjszámítás (FineVisitor)
        
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
                ReturnDate = returnDate;
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
                /*
                book.Accept(visitor);
                totalFine += visitor.GetResult();
                */
                totalFine += book.Accept(visitor);
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
        
        internal void Internal_AddToBooks(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            _books.Add(book);
        }
        
        internal bool Internal_RemoveFromBooks(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            return _books.Remove(book);
        }

        #endregion
    }
}
