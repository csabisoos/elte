namespace TestLibrary;

using Library;

[TestClass]
public class MemberTest
{
    // a) Új tag regisztrálása
    [TestMethod] public void RegisterMember_NewMember_ShouldAddToLibrary()
    {
        var library = new Library();
        var member = new Member( memberId: "M-100", name: "Test User", address: "123 Test St", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));

        library.RegisterMember(member);
            
        var members = library.GetAllMembers().ToList();
        Assert.AreEqual(1, members.Count);
        Assert.AreEqual("M-100", members[0].MemberId);
    }

    // b) Ismételt regisztrálás
    [TestMethod] public void RegisterMember_DuplicateMember_ShouldThrow()
    {
        var library = new Library();
        var member = new Member( memberId: "M-101", name: "Alice", address: "Alice Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        
        library.RegisterMember(member);
        
        Assert.ThrowsException<InvalidOperationException>(() => library.RegisterMember(new Member( memberId: "M-101", name: "Alice Duplicate", address: "Other Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30))));
    }

    // c) Törlés tagság nélkül
    [TestMethod] public void DeregisterMember_NoLoansOrFines_ShouldRemoveMember()
    {
        var library = new Library();
        var member = new Member( memberId: "M-102", name: "Bob", address: "Bob Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        
        library.RegisterMember(member);
        
        library.DeregisterMember("M-102");
            
        Assert.IsFalse(library.IsMember("M-102"));
        Assert.AreEqual(0, library.GetAllMembers().Count());
    }

    // d) Törlés aktív kölcsönzéssel
    [TestMethod] 
    public void DeregisterMember_WithActiveLoan_ShouldThrow()
    {
        var library = new Library();
            
        var book = new ScienceBook( title: "Test Science", author: "Author X", publisher: "Publisher X", isbn: "ISBN-200", copyCount: 0);
        library.AddBook(book, quantity: 1);
            
        var member = new Member( memberId: "M-103", name: "Charlie", address: "Charlie Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        library.RegisterMember(member);
        library.BorrowBooks("M-103", new[] { "ISBN-200" }, DateTime.Now.AddDays(7));
            
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.DeregisterMember("M-103"));
        StringAssert.Contains(ex.Message, "fennálló kölcsönzései");
    }

    // d) Törlés tartozással (lejárt pótdíj)
    [TestMethod]
    public void DeregisterMember_WithOutstandingFineAfterReturn_ShouldThrow()
    {
        // Arrange
        var library = new Library();

        var book = new LiteratureBook("Test Book", "Author", "Publisher", "ISBN-999", 0);
        library.AddBook(book, quantity: 1);

        var member = new Member("M-999", "Late User", "Some Address", DateTime.Now, DateTime.Now.AddDays(30));
        library.RegisterMember(member);

        var loanDate = DateTime.Now.AddDays(-10);
        var dueDate = DateTime.Now.AddDays(-5);      // 5 napja lejárt
        var returnDate = DateTime.Now;               // most visszahozza → késés miatt lesz fine

        library.BorrowBooks("M-999", new[] { "ISBN-999" }, dueDate, loanDate);

        var loan = member.ActiveLoans.First();
        library.ReturnBooks("M-999", new[] { "ISBN-999" }, returnDate);

        // Act & Assert
        Console.WriteLine("ReturnDate: " + loan.ReturnDate);
        Console.WriteLine("DueDate: " + loan.DueDate);
        Console.WriteLine("DaysOverdue: " + loan.DaysOverdue);
        Console.WriteLine("OutstandingFine: " + loan.OutstandingFine);
        Console.WriteLine("HasOutstandingFines: " + member.HasOutstandingFines);
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.DeregisterMember("M-999"));
        StringAssert.Contains(ex.Message, "fennálló kölcsönzései vagy tartozásai");
    }
}