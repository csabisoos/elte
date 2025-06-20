using Library.Books;

namespace Library.Models
{
    public class Member
    {
        public string MemberId           { get; }
        public string Name               { get; set; }
        public string Address            { get; set; }
        public DateTime RegistrationDate { get; }
        
        public DateTime MembershipExpiry { get; private set; }
        private const decimal DailyMembershipRate = 1.0m;

        public decimal MembershipFeeOwed
            => DateTime.Now > MembershipExpiry
               ? (DateTime.Now - MembershipExpiry).Days * DailyMembershipRate
               : 0m;
        
        private readonly List<Loan> _activeLoans = new();
        public IReadOnlyList<Loan> ActiveLoans => _activeLoans;

        private readonly List<Loan> _loanHistory = new();
        public IReadOnlyList<Loan> LoanHistory => _loanHistory;
        
        public bool HasOverdueLoans
            => _activeLoans.Any(loan => loan.IsOverdue());

        public bool CanBorrow
            => _activeLoans.Sum(l => l.Books.Count) < 5
               && MembershipFeeOwed == 0m
               && !HasOverdueLoans;

        public bool HasOutstandingFines
            => _activeLoans.Concat(_loanHistory).Any(l => l.OutstandingFine > 0m);
        
        public Member(
            string memberId,
            string name,
            string address,
            DateTime registrationDate,
            DateTime membershipExpiry)
        {
            MemberId         = memberId ?? throw new ArgumentNullException(nameof(memberId));
            Name             = name     ?? throw new ArgumentNullException(nameof(name));
            Address          = address  ?? throw new ArgumentNullException(nameof(address));
            RegistrationDate = registrationDate;
            MembershipExpiry = membershipExpiry;
        }
        
        public void RenewMembership(DateTime newExpiry)
        {
            if (newExpiry <= MembershipExpiry)
                throw new ArgumentException("Az új lejárati dátumnak későbbinek kell lennie a jelenleginél.", nameof(newExpiry));

            MembershipExpiry = newExpiry;
        }
        
        public void BorrowBooks(IEnumerable<Book> books, DateTime dueDate, DateTime? loanDate = null)
        {
            var bookList = books.ToList();
            if (!CanBorrow || _activeLoans.Sum(l => l.Books.Count) + bookList.Count > 5)
                throw new InvalidOperationException("Nem kölcsönözhet több könyvet.");

            var loan = new Loan(this, bookList, loanDate ?? DateTime.Now, dueDate);
            _activeLoans.Add(loan);
        }
        
        public void ReturnBooks(Loan loan, IEnumerable<Book> booksToReturn, DateTime returnDate)
        {
            if (loan == null) 
                throw new ArgumentNullException(nameof(loan));
            if (!_activeLoans.Contains(loan))
                throw new InvalidOperationException("Ez a kölcsönzés nem aktív ennél a tagnál.");

            var returnList = booksToReturn?.ToList() ?? throw new ArgumentNullException(nameof(booksToReturn));
            if (returnList.Count == 0)
                throw new ArgumentException("Legalább egy könyvet vissza kell hozni.", nameof(booksToReturn));
            
            foreach (var book in returnList)
            {
                loan.RemoveBook(book, returnDate);
            }
            
            if (loan.IsReturned)
            {
                // ReturnDate beállítása a loan.RemoveBook() belső logikája alapján megtörtént
                _activeLoans.Remove(loan);
                _loanHistory.Add(loan);
            }
        }
        
        public decimal PayMembershipFee(DateTime newExpiry)
        {
            if (newExpiry <= MembershipExpiry)
                throw new ArgumentException("Az új lejárati dátumnak későbbinek kell lennie a jelenleginél.", nameof(newExpiry));

            decimal owed = MembershipFeeOwed;
            RenewMembership(newExpiry);
            return owed;
        }
        
        public decimal PayAllFines()
        {
            decimal total = _activeLoans.Sum(l => l.OutstandingFine);
            foreach (var loan in _activeLoans.Where(l => l.OutstandingFine > 0m))
            {
                loan.PayFine();
            }
            return total;
        }
    }
}

