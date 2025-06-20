
using Library.Books;

namespace TestLibrary
{
    using Library;
    [TestClass]
    public class AddBookTest
    {
        [TestMethod]
        public void AddBook_NewBook_DefaultQuantity_ShouldAddOneCopy()
        {
            var library = new Library.Models.Library();
            var book = new ScienceBook(title: "A Brief History of Time", author: "Stephen Hawking", publisher: "Bantam",
                isbn: "ISBN-001", copyCount: 0);

            library.AddBook(book);

            var books = library.GetAllBooks().ToList();
            Assert.AreEqual(1, books.Count);
            Assert.AreEqual("ISBN-001", books[0].ISBN);
            Assert.AreEqual(1, books[0].CopyCount);
        }
        
        [TestMethod]
        public void AddBook_NewBook_WithQuantity3_ShouldAddThreeCopies()
        {
            var library = new Library.Models.Library();
            var book = new LiteratureBook("War and Peace", "Leo Tolstoy", "Vintage", "ISBN-002", 0);
            library.AddBook(book, quantity: 3);
            var books = library.GetAllBooks().ToList();
            Assert.AreEqual(1, books.Count);
            Assert.AreEqual("ISBN-002", books[0].ISBN);
            Assert.AreEqual(3, books[0].CopyCount);
        }
        
        [TestMethod]
        public void AddBook_ExistingBook_IncreaseCopies()
        {
            var library = new Library.Models.Library();
            var book1 = new YouthBook("Harry Potter", "J.K. Rowling", "Bloomsbury", "ISBN-003", 0);
            library.AddBook(book1, 2);
            var book2 = new YouthBook("Harry Potter", "J.K. Rowling", "Bloomsbury", "ISBN-003", 2);
            library.AddBook(book2, 3);
            var books = library.GetAllBooks().ToList();
            Assert.AreEqual(1, books.Count);
            Assert.AreEqual("ISBN-003", books[0].ISBN);
            Assert.AreEqual(5, books[0].CopyCount);
        }
        
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void AddBook_InvalidQuantity_ShouldThrow(int invalidQuantity)
        {
            var library = new Library.Models.Library();
            var book = new ScienceBook("The Selfish Gene", "Richard Dawkins", "Oxford", "ISBN-004", 0);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                library.AddBook(book, invalidQuantity));
        }
    }
}

