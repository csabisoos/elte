namespace TestLibrary;

using Library;

[TestClass]
public class LoanFineTest
{
        // a) Lejárat előtti visszahozás: CalculateFine és OutstandingFine legyen 0
        [TestMethod]
        public void CalculateFine_ReturnBeforeDue_NoFine()
        {
            // Arrange
            var library = new Library();
            var book = new YouthBook("Youth Book", "Author X", "Pub X", "ISBN-F10", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-F10", "Early Return", "Address", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // Könyv kölcsönzése most, dueDate holnapra
            DateTime loanDate = DateTime.Now;
            DateTime dueDate  = DateTime.Now.AddDays(1);
            library.BorrowBooks("M-F10", new[] { "ISBN-F10" }, dueDate, loanDate);

            var loan = member.ActiveLoans.Single();

            // Act: most visszahozzuk (még nem járt le a dueDate)
            DateTime returnDate = DateTime.Now;
            library.ReturnBooks("M-F10", new[] { "ISBN-F10" }, returnDate);

            // Assert
            Assert.AreEqual(0, loan.DaysOverdue);
            Assert.AreEqual(0m, loan.CalculateFine());
            Assert.AreEqual(0m, loan.OutstandingFine);
        }

        // b) Késedelmes visszahozás: CalculateFine és OutstandingFine > 0
        [TestMethod]
        public void CalculateFine_ReturnAfterDue_HasFine()
        {
            var library = new Library();
            var book = new YouthBook("Youth Late", "Author Y", "Pub Y", "ISBN-F11", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-F11", "Late Return", "Address", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // LoanDate 5 nappal ezelőtt, dueDate 2 nappal ezelőtt
            DateTime loanDate = DateTime.Now.AddDays(-5);
            DateTime dueDate  = DateTime.Now.AddDays(-2);
            library.BorrowBooks("M-F11", new[] { "ISBN-F11" }, dueDate, loanDate);

            var loan = member.ActiveLoans.Single();

            // Act: most visszahozzuk (2 nappal késve)
            DateTime returnDate = DateTime.Now;
            library.ReturnBooks("M-F11", new[] { "ISBN-F11" }, returnDate);

            // 2 nap a késés, YouthBook copyCount=1 (ritka, mert 1 < 10), napi szorzó=30 → fine = 2*30=60
            int expectedDaysOverdue = 2;
            decimal expectedFine = expectedDaysOverdue * 30m;

            // Assert
            Assert.AreEqual(expectedDaysOverdue, loan.DaysOverdue);
            Assert.AreEqual(expectedFine, loan.CalculateFine());
            Assert.AreEqual(expectedFine, loan.OutstandingFine);
        }

        // c) Még be nem hozott, de lejárt kölcsönzés: CalculateFine és OutstandingFine > 0
        [TestMethod]
        public void CalculateFine_NotReturnedButOverdue_HasFine()
        {
            // Arrange
            var library = new Library();
            var book = new ScienceBook("Science Late", "Author Z", "Pub Z", "ISBN-F12", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member("M-F12", "No Return", "Address", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // LoanDate 7 nappal ezelőtt, dueDate 3 nappal ezelőtt
            DateTime loanDate = DateTime.Now.AddDays(-7);
            DateTime dueDate  = DateTime.Now.AddDays(-3);
            library.BorrowBooks("M-F12", new[] { "ISBN-F12" }, dueDate, loanDate);

            var loan = member.ActiveLoans.Single();

            // Act: még nem hoztuk vissza, ma van 3 nap késés
            int expectedDaysOverdue = 3;
            // ScienceBook copyCount=1 (ritka, 1<10), napi szorzó=100 → fine = 3*100=300
            decimal expectedFine = expectedDaysOverdue * 100m;

            // Assert
            Assert.AreEqual(expectedDaysOverdue, loan.DaysOverdue);
            Assert.AreEqual(expectedFine, loan.CalculateFine());
            Assert.AreEqual(expectedFine, loan.OutstandingFine);
        }
}