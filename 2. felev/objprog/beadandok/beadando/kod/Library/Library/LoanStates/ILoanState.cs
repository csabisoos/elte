using Library.Books;

namespace Library.LoanStates
{
    public interface ILoanState
    {
        void AddBook(Book book);
        
        void RemoveBook(Book book);
        
        void CloseIfEmpty();
        
        string StateName { get; }
    }
}

