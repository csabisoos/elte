namespace Library
{
    public interface ILoanState
    {
        void AddBook(Book book);
        
        void RemoveBook(Book book);
        
        void CloseIfEmpty();
        
        string StateName { get; }
    }
}

