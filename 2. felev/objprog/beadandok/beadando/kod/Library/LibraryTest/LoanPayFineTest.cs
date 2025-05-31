namespace TestLibrary;

using Library;

[TestClass]
public class LoanPayFineTest
{
        // a) Fizetendő pótdíj befizetése
        [TestMethod]
        public void PayFine_WhenOutstandingFine_PaysAndClearsFine()
        {
            // Arrange
            var library = new Library();
            var book = new ScienceBook("Overdue Science", "Author A", "Publisher A", "ISBN-PF1", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member(
                memberId: "M-PF1",
                name: "Fine Payer",
                address: "Address",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // Loan date 5 nappal ezelőtt, due date 3 nappal ezelőtt → 3 nap késés
            DateTime loanDate = DateTime.Now.AddDays(-5);
            DateTime dueDate  = DateTime.Now.AddDays(-3);
            library.BorrowBooks("M-PF1", new[] { "ISBN-PF1" }, dueDate, loanDate);

            // Hozzuk vissza most, hogy a pótdíj számolódjon és a Loan átkerüljön LoanHistory-be
            library.ReturnBooks("M-PF1", new[] { "ISBN-PF1" }, DateTime.Now);

            // Ellenőrizzük, van-e tényleges pótdíj
            var loanHistory = member.LoanHistory.Single();
            Assert.IsTrue(loanHistory.OutstandingFine > 0m);

            decimal expectedFine = loanHistory.CalculateFine();

            // Act: befizetjük a pótdíjat a Library metódussal
            decimal paid = library.PayFines("M-PF1");

            // Assert
            Assert.AreEqual(expectedFine, paid, "A visszaadott összegnek egyeznie kell a kiszámolt pótdíjjal.");

            // Most már nem lehet kitartozása
            Assert.AreEqual(0m, loanHistory.OutstandingFine);
        }

        // b) Fizetés nélkül, pótdíj nélkül: PayFines visszaadjon 0-t, ne dobjon kivételt
        [TestMethod]
        public void PayFine_WhenNoOutstandingFine_ReturnsZero()
        {
            // Arrange
            var library = new Library();
            var book = new YouthBook("No Fine Youth", "Author B", "Publisher B", "ISBN-PF2", 0);
            library.AddBook(book, quantity: 1);

            var member = new Member(
                memberId: "M-PF2",
                name: "No Fine User",
                address: "Address",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // Könyv kölcsönzése most, dueDate holnapra → nincs pótdíj
            library.BorrowBooks("M-PF2", new[] { "ISBN-PF2" }, DateTime.Now.AddDays(1));

            // A tag nem hozta vissza, de még nem járt le a lejárati idő, így nincs overdue
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(0, loan.DaysOverdue);
            Assert.AreEqual(0m, loan.OutstandingFine);

            // Act
            decimal paid = library.PayFines("M-PF2");

            // Assert
            Assert.AreEqual(0m, paid, "Ha nincs pótdíj, PayFines nulla értéket adjon vissza.");
        }
}