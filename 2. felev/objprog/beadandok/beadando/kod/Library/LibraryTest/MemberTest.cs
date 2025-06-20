using Library.Models;

namespace TestLibrary;

using Library;
using Library.Books;

[TestClass]
public class MemberTest
{
    [TestMethod] public void RegisterMember_NewMember_ShouldAddToLibrary()
    {
        var library = new Library.Models.Library();
        var member = new Member( memberId: "M-100", name: "Test User", address: "123 Test St", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));

        library.RegisterMember(member);
            
        var members = library.GetAllMembers().ToList();
        Assert.AreEqual(1, members.Count);
        Assert.AreEqual("M-100", members[0].MemberId);
    }
    
    [TestMethod] public void RegisterMember_DuplicateMember_ShouldThrow()
    {
        var library = new Library.Models.Library();
        var member = new Member( memberId: "M-101", name: "Alice", address: "Alice Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        
        library.RegisterMember(member);
        
        Assert.ThrowsException<InvalidOperationException>(() => library.RegisterMember(new Member( memberId: "M-101", name: "Alice Duplicate", address: "Other Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30))));
    }
    
    [TestMethod] public void DeregisterMember_NoLoansOrFines_ShouldRemoveMember()
    {
        var library = new Library.Models.Library();
        var member = new Member( memberId: "M-102", name: "Bob", address: "Bob Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        
        library.RegisterMember(member);
        
        library.DeregisterMember("M-102");
            
        Assert.IsFalse(library.IsMember("M-102"));
        Assert.AreEqual(0, library.GetAllMembers().Count());
    }
    
    [TestMethod] 
    public void DeregisterMember_WithActiveLoan_ShouldThrow()
    {
        var library = new Library.Models.Library();
            
        var book = new ScienceBook( title: "Test Science", author: "Author X", publisher: "Publisher X", isbn: "ISBN-200", copyCount: 0);
        library.AddBook(book, quantity: 1);
            
        var member = new Member( memberId: "M-103", name: "Charlie", address: "Charlie Address", registrationDate: DateTime.Now, membershipExpiry: DateTime.Now.AddDays(30));
        library.RegisterMember(member);
        library.BorrowBooks("M-103", new[] { "ISBN-200" }, DateTime.Now.AddDays(7));
            
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            library.DeregisterMember("M-103"));
        StringAssert.Contains(ex.Message, "fennálló kölcsönzései");
    }
}