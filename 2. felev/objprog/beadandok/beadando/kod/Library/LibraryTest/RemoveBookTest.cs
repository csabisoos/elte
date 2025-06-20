using Library.Books;
using Library.Models;

namespace TestLibrary;

using Library;

[TestClass]
public class RemoveBookTest
{
    [TestMethod]
    public void RemoveBook_DecreaseCopies_WhenQuantityLessThanCount()
    {
        var library = new Library.Models.Library();
        var book = new ScienceBook("Test Science", "Author A", "Publisher A", "ISBN-100", 0);
        library.AddBook(book, quantity: 5);  
        
        library.RemoveBook("ISBN-100", quantity: 3);

        var stored = library.GetAllBooks().Single();
        Assert.AreEqual("ISBN-100", stored.ISBN);
        Assert.AreEqual(2, stored.CopyCount);
    }
    
    [TestMethod]
    public void RemoveBook_RemoveEntireBook_WhenQuantityEqualsCount()
    {
        var library = new Library.Models.Library();
        var book = new LiteratureBook("Test Lit", "Author B", "Publisher B", "ISBN-101", 0);
        library.AddBook(book, quantity: 4);  
        
        library.RemoveBook("ISBN-101", quantity: 4);
        
        Assert.IsFalse(library.GetAllBooks().Any(b => b.ISBN == "ISBN-101"));
    }
    
    [TestMethod]
    public void RemoveBook_Throws_WhenBookIsOnLoan()
    {
        var library = new Library.Models.Library();
        var book = new YouthBook("Test Youth", "Author C", "Publisher C", "ISBN-102", 0);
        library.AddBook(book, quantity: 2);  

        var member = new Member("M-001", "Test Name", "Some Address", DateTime.Now, DateTime.Now.AddDays(30));
        library.RegisterMember(member);
        library.BorrowBooks("M-001", new[] { "ISBN-102" }, DateTime.Now.AddDays(7));
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.RemoveBook("ISBN-102", quantity: 1));
        StringAssert.Contains(ex.Message, "jelenleg ki van kölcsönözve");
    }
    
    [DataTestMethod]
    [DataRow(0)]
    [DataRow(-5)]
    public void RemoveBook_InvalidQuantity_ShouldThrow(int invalidQuantity)
    {
        var library = new Library.Models.Library();
        var book = new ScienceBook("Test Sci", "Author D", "Publisher D", "ISBN-103", 0);
        library.AddBook(book, quantity: 3);  
        
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            library.RemoveBook("ISBN-103", invalidQuantity));
    }
    
    [TestMethod]
    public void RemoveBook_NonexistentISBN_ShouldThrow()
    {
        var library = new Library.Models.Library();
        var book = new LiteratureBook("Test Lit2", "Author E", "Publisher E", "ISBN-104", 0);
        library.AddBook(book, quantity: 1);  
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.RemoveBook("NON-EXISTENT-ISBN", quantity: 1));
        StringAssert.Contains(ex.Message, "Nincs ilyen könyv");
    }
}