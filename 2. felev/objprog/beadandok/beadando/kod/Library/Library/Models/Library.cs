using Library.Books;

namespace Library.Models
{
    public class Library
    {
        private readonly List<Book> _inventory = new();
        private readonly List<Member> _members = new();
        private readonly List<Loan> _allLoans = new();
        
        public void AddBook(Book book, int quantity = 1)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            var existing = _inventory.FirstOrDefault(b => b.ISBN == book.ISBN);
            if (existing != null)
            {
                existing.IncreaseCopies(quantity);
            }
            else
            {
                if (quantity != book.CopyCount)
                    book.IncreaseCopies(quantity - book.CopyCount);
                _inventory.Add(book);
            }
        }

        public void RemoveBook(string isbn, int quantity = 1)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            var book = _inventory.FirstOrDefault(b => b.ISBN == isbn)
                       ?? throw new InvalidOperationException("Nincs ilyen könyv az állományban.");
            
            if (_allLoans.Any(l => l.Books.Any(b => b.ISBN == isbn) && !l.IsReturned))
                throw new InvalidOperationException("A könyv jelenleg ki van kölcsönözve.");

            if (book.CopyCount > quantity)
            {
                book.DecreaseCopies(quantity);
            }
            else
            {
                _inventory.Remove(book);
            }
        }
        
        public void RegisterMember(Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
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
        
        public void BorrowBooks(string memberId, IEnumerable<string> isbns, DateTime dueDate, DateTime? loanDate = null)
        {
            var member = _members.FirstOrDefault(m => m.MemberId == memberId)
                         ?? throw new InvalidOperationException("Nincs ilyen tag.");

            var books = isbns.Select(isbn =>
            {
                var b = _inventory.FirstOrDefault(x => x.ISBN == isbn)
                        ?? throw new InvalidOperationException($"Nincs ilyen könyv ({isbn}).");
                if (b.CopyCount <= 0)
                    throw new InvalidOperationException($"A '{b.Title}' példánya elfogyott.");
                b.DecreaseCopies(1);
                return b;
            }).ToList();

            member.BorrowBooks(books, dueDate, loanDate);
            var newLoan = member.ActiveLoans.Last();
            _allLoans.Add(newLoan);
        }

        public void ReturnBooks(string memberId, IEnumerable<string> isbns, DateTime returnDate)
        {
            var member = _members.FirstOrDefault(m => m.MemberId == memberId)
                         ?? throw new InvalidOperationException("Nincs ilyen tag.");

            foreach (var isbn in isbns)
            {
                var loan = member.ActiveLoans
                    .FirstOrDefault(l => l.Books.Any(b => b.ISBN == isbn))
                    ?? throw new InvalidOperationException($"A könyv ({isbn}) nincs kölcsönözve ennél a tagnál.");

                var book = loan.Books.First(b => b.ISBN == isbn);
                
                member.ReturnBooks(loan, new[] { book }, returnDate);

                // Mivel a Member.RemoveBook már eltávolította a könyvet a loan-ból,
                // ha a loan üressé vált, a Member mindent elvégzett (ReturnDate, áthelyezés history-ba)
                // Itt csak vissza kell növelnünk a példányszámot:
                book.IncreaseCopies(1);
            }
        }
        
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
        
        public bool IsMember(string memberId)
            => _members.Any(m => m.MemberId == memberId);

        public bool IsBookAvailable(string isbn)
            => _inventory.Any(b => b.ISBN == isbn)
               && !_allLoans.Any(l => l.Books.Any(b => b.ISBN == isbn) && !l.IsReturned);

        public decimal GetMemberDebt(string memberId)
        {
            var m = _members.FirstOrDefault(x => x.MemberId == memberId)
                    ?? throw new InvalidOperationException("Nincs ilyen tag.");
            return m.MembershipFeeOwed + m.ActiveLoans.Concat(m.LoanHistory).Sum(l => l.OutstandingFine);
        }

        public IEnumerable<Book> FindBooksByTitle(string title)
            => _inventory.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Member> GetAllMembers() => _members.AsReadOnly();
        public IEnumerable<Book>   GetAllBooks()   => _inventory.AsReadOnly();
        public IEnumerable<Loan>   GetAllLoans()   => _allLoans.AsReadOnly();
    }
}
