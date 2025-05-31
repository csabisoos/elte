namespace TestLibrary;

using Library;

[TestClass]
public class RemoveBookTest
{
    // a) Példányszám csökkentése
    [TestMethod]
    public void RemoveBook_DecreaseCopies_WhenQuantityLessThanCount()
    {
        var library = new Library();
        var book = new ScienceBook("Test Science", "Author A", "Publisher A", "ISBN-100", 0);
        library.AddBook(book, quantity: 5);  // CopyCount = 5
        
        library.RemoveBook("ISBN-100", quantity: 3);

        var stored = library.GetAllBooks().Single();
        Assert.AreEqual("ISBN-100", stored.ISBN);
        Assert.AreEqual(2, stored.CopyCount);
    }
    
    // b) Teljes törlés, ha a példányszám a quantity-vel egyenlő
    [TestMethod]
    public void RemoveBook_RemoveEntireBook_WhenQuantityEqualsCount()
    {
        var library = new Library();
        var book = new LiteratureBook("Test Lit", "Author B", "Publisher B", "ISBN-101", 0);
        library.AddBook(book, quantity: 4);  // CopyCount = 4
        
        library.RemoveBook("ISBN-101", quantity: 4);
        
        Assert.IsFalse(library.GetAllBooks().Any(b => b.ISBN == "ISBN-101"));
    }
    
    // c) Eltávolítás kölcsönzött könyvnél → InvalidOperationException
    [TestMethod]
    public void RemoveBook_Throws_WhenBookIsOnLoan()
    {
        var library = new Library();
        var book = new YouthBook("Test Youth", "Author C", "Publisher C", "ISBN-102", 0);
        library.AddBook(book, quantity: 2);  // CopyCount = 2

        var member = new Member("M-001", "Test Name", "Some Address", DateTime.Now, DateTime.Now.AddDays(30));
        library.RegisterMember(member);
        library.BorrowBooks("M-001", new[] { "ISBN-102" }, DateTime.Now.AddDays(7));
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.RemoveBook("ISBN-102", quantity: 1));
        StringAssert.Contains(ex.Message, "jelenleg ki van kölcsönözve");
    }
    
    // d) Hibás mennyiség (0 vagy negatív) → ArgumentOutOfRangeException
    [DataTestMethod]
    [DataRow(0)]
    [DataRow(-5)]
    public void RemoveBook_InvalidQuantity_ShouldThrow(int invalidQuantity)
    {
        var library = new Library();
        var book = new ScienceBook("Test Sci", "Author D", "Publisher D", "ISBN-103", 0);
        library.AddBook(book, quantity: 3);  // CopyCount = 3
        
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            library.RemoveBook("ISBN-103", invalidQuantity));
    }

    // e) Nem létező ISBN → InvalidOperationException
    [TestMethod]
    public void RemoveBook_NonexistentISBN_ShouldThrow()
    {
        var library = new Library();
        var book = new LiteratureBook("Test Lit2", "Author E", "Publisher E", "ISBN-104", 0);
        library.AddBook(book, quantity: 1);  // csak ISBN-104 létezik
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.RemoveBook("NON-EXISTENT-ISBN", quantity: 1));
        StringAssert.Contains(ex.Message, "Nincs ilyen könyv");
    }
}