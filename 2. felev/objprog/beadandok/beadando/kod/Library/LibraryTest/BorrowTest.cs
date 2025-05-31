namespace TestLibrary;

using Library;

[TestClass]
public class BorrowTest
{
        // a) Egy könyv kölcsönzése
        [TestMethod]
        public void BorrowBooks_SingleBook_ShouldSucceed()
        {
            // Arrange
            var library = new Library();
            var book = new ScienceBook("Test Science", "Author A", "Publisher A", "ISBN-300", 0);
            library.AddBook(book, quantity: 1);  // CopyCount = 1

            var member = new Member(
                memberId: "M-200",
                name: "Test Member",
                address: "Some Address",
                registrationDate: DateTime.Now,
                membershipExpiry: DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // Act
            library.BorrowBooks("M-200", new[] { "ISBN-300" }, DateTime.Now.AddDays(7));

            // Assert
            // 1. A könyv példányszáma csökkent 0-ra
            var storedBook = library.GetAllBooks().Single(b => b.ISBN == "ISBN-300");
            Assert.AreEqual(0, storedBook.CopyCount);

            // 2. A tag aktív kölcsönzéseinek száma 1
            Assert.AreEqual(1, member.ActiveLoans.Count);

            // 3. Az aktív Loan rendelkezik pontosan egy könyvvel
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(1, loan.Books.Count);
            Assert.AreEqual("ISBN-300", loan.Books.Single().ISBN);
        }

        // b) Több könyv egy eseményben
        [TestMethod]
        public void BorrowBooks_MultipleBooks_ShouldSucceed()
        {
            // Arrange
            var library = new Library();
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

            // Act
            library.BorrowBooks("M-201", new[] { "ISBN-301", "ISBN-302", "ISBN-303" }, DateTime.Now.AddDays(7));

            // Assert
            // A példányszámok csökkentek
            Assert.AreEqual(1, library.GetAllBooks().Single(b => b.ISBN == "ISBN-301").CopyCount); // 2 → 1
            Assert.AreEqual(0, library.GetAllBooks().Single(b => b.ISBN == "ISBN-302").CopyCount); // 1 → 0
            Assert.AreEqual(2, library.GetAllBooks().Single(b => b.ISBN == "ISBN-303").CopyCount); // 3 → 2

            // A tag egyetlen Loan-ban tartja a 3 könyvet
            Assert.AreEqual(1, member.ActiveLoans.Count);
            var loan = member.ActiveLoans.Single();
            Assert.AreEqual(3, loan.Books.Count);
            CollectionAssert.AreEquivalent(
                new[] { "ISBN-301", "ISBN-302", "ISBN-303" },
                loan.Books.Select(b => b.ISBN).ToArray()
            );
        }

        // c) Könyvkorlát túllépése (>5)
        [TestMethod]
        public void BorrowBooks_ExceedsBookLimit_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            // Készletbe legalább 6 különböző ISBN
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

            // Act & Assert
            // Megpróbálunk 6 könyvet egy alkalommal kölcsönözni → InvalidOperationException
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-202",
                    new[] { "ISBN-400", "ISBN-401", "ISBN-402", "ISBN-403", "ISBN-404", "ISBN-405" },
                    DateTime.Now.AddDays(7)));
        }

        // c2) Könyvkorlát túllépése utólag (először 4, majd 2 további)
        [TestMethod]
        public void BorrowBooks_ExceedsBookLimitInMultipleSteps_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            // Készletbe 6 ISBN
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

            // Első alkalommal kölcsönözzen 4-et
            library.BorrowBooks("M-203",
                new[] { "ISBN-500", "ISBN-501", "ISBN-502", "ISBN-503" },
                DateTime.Now.AddDays(7));

            // Most már 4 könyv van nála, próbáljon meg 2-t kölcsönözni → összesen 6 > 5 → hiba
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-203",
                    new[] { "ISBN-504", "ISBN-505" },
                    DateTime.Now.AddDays(7)));
        }

        // d) Példányhiány
        [TestMethod]
        public void BorrowBooks_OutOfStock_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            var book = new YouthBook("Rare Book", "Author Z", "Publisher Z", "ISBN-600", 0);
            library.AddBook(book, quantity: 1); // CopyCount = 1

            var member1 = new Member("M-300", "First", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            var member2 = new Member("M-301", "Second", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member1);
            library.RegisterMember(member2);

            // Első tag kölcsönöz egy példányt
            library.BorrowBooks("M-300", new[] { "ISBN-600" }, DateTime.Now.AddDays(7));

            // Második tag megpróbálja ugyanazt a könyvet kölcsönözni → CopyCount=0 → hiba
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-301", new[] { "ISBN-600" }, DateTime.Now.AddDays(7)));
        }

        // e) Helytelen memberId vagy isbn
        [TestMethod]
        public void BorrowBooks_InvalidMemberId_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            var book = new ScienceBook("Any", "Auth", "Pub", "ISBN-700", 0);
            library.AddBook(book, quantity: 1);

            // Az "UNKNOWN" tag nem létezik → InvalidOperationException
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("UNKNOWN", new[] { "ISBN-700" }, DateTime.Now.AddDays(7)));
        }

        [TestMethod]
        public void BorrowBooks_InvalidIsbn_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            var member = new Member("M-400", "NoBookUser", "Addr", DateTime.Now, DateTime.Now.AddDays(30));
            library.RegisterMember(member);

            // Az "NON-EXISTENT-ISBN" nincs a készletben → InvalidOperationException
            Assert.ThrowsException<InvalidOperationException>(() =>
                library.BorrowBooks("M-400", new[] { "NON-EXISTENT-ISBN" }, DateTime.Now.AddDays(7)));
        }
}