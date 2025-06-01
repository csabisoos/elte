using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Models
{
    public class Member
    {
        // --- Személyes adatok ---
        public string MemberId           { get; }
        public string Name               { get; set; }
        public string Address            { get; set; }
        public DateTime RegistrationDate { get; }

        // --- Tagsági díj-kezelés ---
        public DateTime MembershipExpiry { get; private set; }

        // Napi tagdíj rátája (például 1 egység/nap)
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

        // --- Tagság megújítása ---
        public void RenewMembership(DateTime newExpiry)
        {
            if (newExpiry <= MembershipExpiry)
                throw new ArgumentException("Az új lejárati dátumnak későbbinek kell lennie a jelenleginél.", nameof(newExpiry));
            MembershipExpiry = newExpiry;
        }

        // --- Könyvek kölcsönzése ---
        public void BorrowBooks(IEnumerable<Book> books, DateTime dueDate)
        {
            var bookList = books?.ToList() ?? throw new ArgumentNullException(nameof(books));

            // Ellenőrizzük, hogy összesen hány könyv van nála a kért kölcsönzés után
            int currentCount = _activeLoans.Sum(l => l.Books.Count);
            if (bookList.Count == 0)
                throw new ArgumentException("Legalább egy könyvet meg kell adni kölcsönzéskor.", nameof(books));
            if (currentCount + bookList.Count > 5)
                throw new InvalidOperationException("Nem kölcsönözhet több könyvet.");

            if (MembershipFeeOwed > 0m)
                throw new InvalidOperationException("Lejárt tagsági díja van.");

            if (HasOverdueLoans)
                throw new InvalidOperationException("Van lejárt kölcsönzése.");

            // Létrehozunk egy új Loan-t a könyvekkel
            var loan = new Loan(this, bookList, DateTime.Now, dueDate);
            _activeLoans.Add(loan);
        }

        // --- Részleges vagy teljes visszahozás ---
        public void ReturnBooks(Loan loan, IEnumerable<Book> booksToReturn, DateTime returnDate)
        {
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));
            if (!_activeLoans.Contains(loan))
                throw new InvalidOperationException("Ez a kölcsönzés nem aktív ennél a tagnál.");
        
            var returnList = booksToReturn?.ToList() ?? throw new ArgumentNullException(nameof(booksToReturn));
            if (returnList.Count == 0)
                throw new ArgumentException("Legalább egy könyvet vissza kell hozni.", nameof(booksToReturn));
        
            // Minden visszahozott könyvnél hívjuk a loan.RemoveBook(book, returnDate)-t
            foreach (var book in returnList)
            {
                loan.RemoveBook(book, returnDate);
            }
        
            // Ha a Loan-ból már nem maradt egy darab könyv sem, akkor lezártuk:
            // (az IsReturned azt jelzi, hogy ReturnDate beállításra került az "üresre" logika szerint)
            if (loan.IsReturned)
            {
                _activeLoans.Remove(loan);
                _loanHistory.Add(loan);
            }
        }

        // --- Tagdíj befizetése ---
        public decimal PayMembershipFee(DateTime newExpiry)
        {
            if (newExpiry <= MembershipExpiry)
                throw new ArgumentException("Az új lejárati dátumnak későbbinek kell lennie a jelenleginél.", nameof(newExpiry));

            decimal owed = MembershipFeeOwed;
            RenewMembership(newExpiry);
            return owed;
        }

        // --- Pótdíjak befizetése ---
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
