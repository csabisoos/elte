using Library.Books;
using Library.Models;

namespace TestLibrary;

using Library;

[TestClass]
public class ReturnTest
{
        [TestMethod]
        public void ReturnBooks_PartialReturn_ShouldKeepLoanActive()
        {
            var library = new Library.Models.Library();
            
            var book1 = new ScienceBook("Sci One", "Author A", "Pub A", "ISBN-800", 0);
            var book2 = new LiteratureBook("Lit One", "Author B", "Pub B", "ISBN-801", 0);
            library.AddBook(book1, quantity: 1);
            library.AddBook(book2, quantity: 1);
            
            var member = new Member("M-500", "Partial User", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            library.BorrowBooks("M-500", new[] { "ISBN-800", "ISBN-801" }, DateTime.Now.AddDays(7));
            
            library.ReturnBooks("M-500", new[] { "ISBN-800" }, DateTime.Now);
            
            var storedBook1 = library.GetAllBooks().Single(b => b.ISBN == "ISBN-800");
            Assert.AreEqual(1, storedBook1.CopyCount);
            
            Assert.AreEqual(1, member.ActiveLoans.Count);
            
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(1, loan.Books.Count);
            Assert.AreEqual("ISBN-801", loan.Books.Single().ISBN);
        }
        
        [TestMethod]
        public void ReturnBooks_FullReturn_ShouldRemoveLoanAndAddToHistory()
        {
            var library = new Library.Models.Library();

            var book = new YouthBook("Youth One", "Author C", "Pub C", "ISBN-802", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-501", "Full User", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            library.BorrowBooks("M-501", new[] { "ISBN-802" }, DateTime.Now.AddDays(7));
            
            library.ReturnBooks("M-501", new[] { "ISBN-802" }, DateTime.Now);
            
            var storedBook = library.GetAllBooks().Single(b => b.ISBN == "ISBN-802");
            Assert.AreEqual(1, storedBook.CopyCount);
            
            Assert.AreEqual(0, member.ActiveLoans.Count);
            
            Assert.AreEqual(1, member.LoanHistory.Count);
            var closedLoan = member.LoanHistory.Single();
            Assert.IsTrue(closedLoan.IsReturned);
        }
        
        [TestMethod]
        public void ReturnBooks_NotOnLoan_ShouldThrow()
        {
            var library = new Library.Models.Library();

            var book = new ScienceBook("Unloaned", "Author D", "Pub D", "ISBN-803", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-502", "NoLoan User", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                library.ReturnBooks("M-502", new[] { "ISBN-803" }, DateTime.Now));
            StringAssert.Contains(ex.Message, "nincs kölcsönözve");
        }
        
        [TestMethod]
        public void ReturnBooks_InvalidMemberId_ShouldThrow()
        {
            var library = new Library.Models.Library();

            var book = new LiteratureBook("Test", "Author E", "Pub E", "ISBN-804", 0);
            library.AddBook(book, quantity: 1);
            
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                library.ReturnBooks("UNKNOWN", new[] { "ISBN-804" }, DateTime.Now));
            StringAssert.Contains(ex.Message, "Nincs ilyen tag");
        }

        [TestMethod]
        public void ReturnBooks_InvalidIsbn_ShouldThrow()
        {
            var library = new Library.Models.Library();

            var member = new Member("M-503", "Some User", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                library.ReturnBooks("M-503", new[] { "NON-EXISTENT-ISBN" }, DateTime.Now));
            StringAssert.Contains(ex.Message, "nincs kölcsönözve");
        }
}