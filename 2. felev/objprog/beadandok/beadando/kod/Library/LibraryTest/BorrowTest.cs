using Library.Books;
using Library.Models;

namespace TestLibrary;

using Library;

[TestClass]
public class BorrowTest
{
        [TestMethod]
        public void BorrowBooks_SingleBook_ShouldSucceed()
        {
            var library = new Library.Models.Library();
            var book = new ScienceBook("Test Science", "Author A", "Publisher A", "ISBN-300", 0);
            library.AddBook(book, quantity: 1);  

            var member = new Member(
                memberId: "M-200",
                name: "Test Member",
                address: "Some Address",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            library.BorrowBooks("M-200", new[] { "ISBN-300" }, DateTime.Now.AddDays(7));
            
            var storedBook = library.GetAllBooks().Single(b => b.ISBN == "ISBN-300");
            Assert.AreEqual(0, storedBook.CopyCount);
            
            Assert.AreEqual(1, member.ActiveLoans.Count);
            
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(1, loan.Books.Count);
            Assert.AreEqual("ISBN-300", loan.Books.Single().ISBN);
        }
        
        [TestMethod]
        public void BorrowBooks_MultipleBooks_ShouldSucceed()
        {
            var library = new Library.Models.Library();
            var book1 = new LiteratureBook("Test Lit1", "Author B", "Publisher B", "ISBN-301", 0);
            var book2 = new YouthBook("Test Youth", "Author C", "Publisher C", "ISBN-302", 0);
            var book3 = new ScienceBook("Test Sci", "Author D", "Publisher D", "ISBN-303", 0);
            library.AddBook(book1, quantity: 2);
            library.AddBook(book2, quantity: 1);
            library.AddBook(book3, quantity: 3);

            var member = new Member(
                memberId: "M-201",
                name: "Multi Borrower",
                address: "Some Address",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            library.BorrowBooks("M-201", new[] { "ISBN-301", "ISBN-302", "ISBN-303" }, DateTime.Now.AddDays(7));
            
            Assert.AreEqual(1, library.GetAllBooks().Single(b => b.ISBN == "ISBN-301").CopyCount); 
            Assert.AreEqual(0, library.GetAllBooks().Single(b => b.ISBN == "ISBN-302").CopyCount); 
            Assert.AreEqual(2, library.GetAllBooks().Single(b => b.ISBN == "ISBN-303").CopyCount); 
            
            Assert.AreEqual(1, member.ActiveLoans.Count);
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(3, loan.Books.Count);
            CollectionAssert.AreEquivalent(
                new[] { "ISBN-301", "ISBN-302", "ISBN-303" },
                loan.Books.Select(b => b.ISBN).ToArray()
            );
        }
        
        [TestMethod]
        public void BorrowBooks_ExceedsBookLimit_ShouldThrow()
        {
            var library = new Library.Models.Library();
            for (int i = 0; i < 6; i++)
            {
                var isbn = $"ISBN-40{i}";
                var book = new ScienceBook($"Book{i}", $"Author{i}", $"Publisher{i}", isbn, 0);
                library.AddBook(book, quantity: 1);
            }

            var member = new Member(
                memberId: "M-202",
                name: "OverLimiter",
                address: "Addr",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-202",
                    new[] { "ISBN-400", "ISBN-401", "ISBN-402", "ISBN-403", "ISBN-404", "ISBN-405" },
                    DateTime.Now.AddDays(7)));
        }
        
        [TestMethod]
        public void BorrowBooks_ExceedsBookLimitInMultipleSteps_ShouldThrow()
        {
            var library = new Library.Models.Library();
            for (int i = 0; i < 6; i++)
            {
                var isbn = $"ISBN-50{i}";
                var book = new LiteratureBook($"Book{i}", $"Author{i}", $"Publisher{i}", isbn, 0);
                library.AddBook(book, quantity: 1);
            }

            var member = new Member(
                memberId: "M-203",
                name: "StepLimiter",
                address: "Addr",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            library.BorrowBooks("M-203",
                new[] { "ISBN-500", "ISBN-501", "ISBN-502", "ISBN-503" },
                DateTime.Now.AddDays(7));
            
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-203",
                    new[] { "ISBN-504", "ISBN-505" },
                    DateTime.Now.AddDays(7)));
        }
        
        [TestMethod]
        public void BorrowBooks_OutOfStock_ShouldThrow()
        {
            var library = new Library.Models.Library();
            var book = new YouthBook("Rare Book", "Author Z", "Publisher Z", "ISBN-600", 0);
            library.AddBook(book, quantity: 1); 

            var member1 = new Member("M-300", "First", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            var member2 = new Member("M-301", "Second", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member1);
            library.RegisterMember(member2);
            
            library.BorrowBooks("M-300", new[] { "ISBN-600" }, DateTime.Now.AddDays(7));
            
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-301", new[] { "ISBN-600" }, DateTime.Now.AddDays(7)));
        }
        
        [TestMethod]
        public void BorrowBooks_InvalidMemberId_ShouldThrow()
        {
            var library = new Library.Models.Library();
            var book = new ScienceBook("Any", "Auth", "Pub", "ISBN-700", 0);
            library.AddBook(book, quantity: 1);
            
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("UNKNOWN", new[] { "ISBN-700" }, DateTime.Now.AddDays(7)));
        }

        [TestMethod]
        public void BorrowBooks_InvalidIsbn_ShouldThrow()
        {
            var library = new Library.Models.Library();
            var member = new Member("M-400", "NoBookUser", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-400", new[] { "NON-EXISTENT-ISBN" }, DateTime.Now.AddDays(7)));
        }
}