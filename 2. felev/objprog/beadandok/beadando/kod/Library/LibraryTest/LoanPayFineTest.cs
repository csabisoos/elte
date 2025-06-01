namespace TestLibrary;

using Library;

[TestClass]
public class LoanPayFineTest
{
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