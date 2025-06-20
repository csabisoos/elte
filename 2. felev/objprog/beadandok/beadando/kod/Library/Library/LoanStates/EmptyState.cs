using Library.Books;
using Library.Models;

namespace Library.LoanStates
{
    public class EmptyState : ILoanState
    {
        private readonly Loan _loan;

        public EmptyState(Loan loan)
        {
            _loan = loan ?? throw new ArgumentNullException(nameof(loan));
        }

        public string StateName => "Empty";

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            
            _loan.Internal_AddToBooks(book);
            _loan.ChangeState(new IntermediateState(_loan));
        }

        public void RemoveBook(Book book)
        {
            throw new InvalidOperationException("Nincs mit visszahozni, mert ez a kölcsönzés üres állapotú.");
        }

        public void CloseIfEmpty()
        {
            // Ha már eleve üres, itt nincs további teendő.
            // (ReturnDate-et akkor állítjuk be, amikor a RemoveBook az utolsó könyvet eltávolítja,
            // de EmptyState esetén nem hívjuk meg újra.)
        }
    }
}
