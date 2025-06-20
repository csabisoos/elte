using Library.Models;

namespace TestLibrary;

using Library;
using Library.Books;


[TestClass]
public class LoanFineTest
{
        [TestMethod]
        public void CalculateFine_ReturnBeforeDue_NoFine()
        {
            var library = new Library.Models.Library();
            var book = new YouthBook("Youth Book", "Author X", "Pub X", "ISBN-F10", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-F10", "Early Return", "Address", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            DateTime loanDate = DateTime.Now;
            DateTime dueDate  = DateTime.Now.AddDays(1);
            library.BorrowBooks("M-F10", new[] { "ISBN-F10" }, dueDate, loanDate);

            var loan = member.ActiveLoans.Single();
            
            DateTime returnDate = DateTime.Now;
            library.ReturnBooks("M-F10", new[] { "ISBN-F10" }, returnDate);
            
            Assert.AreEqual(0, loan.DaysOverdue);
            Assert.AreEqual(0m, loan.CalculateFine());
            Assert.AreEqual(0m, loan.OutstandingFine);
        }
        
        [TestMethod]
        public void CalculateFine_NotReturnedButOverdue_HasFine()
        {
            var library = new Library.Models.Library();
            var book = new ScienceBook("Science Late", "Author Z", "Pub Z", "ISBN-F12", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-F12", "No Return", "Address", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);
            
            DateTime loanDate = DateTime.Now.AddDays(-7);
            DateTime dueDate  = DateTime.Now.AddDays(-3);
            library.BorrowBooks("M-F12", new[] { "ISBN-F12" }, dueDate, loanDate);

            var loan = member.ActiveLoans.Single();
            
            int expectedDaysOverdue = 3;
            decimal expectedFine = expectedDaysOverdue * 100m;
            
            Assert.AreEqual(expectedDaysOverdue, loan.DaysOverdue);
            Assert.AreEqual(expectedFine, loan.CalculateFine());
            Assert.AreEqual(expectedFine, loan.OutstandingFine);
        }
}