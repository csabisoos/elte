using System;

namespace YourNamespace.Models
{
    /// <summary>
    /// „Köztes” állapot: a Loan._books.Count 1 és 4 között van.
    /// Itt már hozzá lehet adni további könyveket, de maximum 5-ig. Ha 5 lesz,
    /// FullState-be váltunk. Visszahozáskor, ha 0 lesz, EmptyState-be kerülünk.
    /// </summary>
    public class IntermediateState : ILoanState
    {
        private readonly Loan _loan;

        public IntermediateState(Loan loan)
        {
            _loan = loan ?? throw new ArgumentNullException(nameof(loan));
        }

        public string StateName => "Intermediate";

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            // Jelenleg 1–4 könyv lehet. Ha hozzáadva 5 lesz, FullState.
            _loan.Internal_AddToBooks(book);
            int count = _loan.InternalBookCount;
            if (count == 5)
                _loan.ChangeState(new FullState(_loan));
            // különben marad IntermediateState
        }

        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool removed = _loan.Internal_RemoveFromBooks(book);
            if (!removed)
                throw new InvalidOperationException("Ez a könyv nem része ennek a kölcsönzésnek.");

            if (_loan.InternalBookCount == 0)
            {
                // Utolsó könyv visszahozása → EmptyState és ReturnDate beállítása
                _loan.ReturnDate = DateTime.Now;
                _loan.ChangeState(new EmptyState(_loan));
            }
            // ha maradt 1–4 könyv, marad IntermediateState
        }

        public void CloseIfEmpty()
        {
            if (_loan.InternalBookCount != 0)
                throw new InvalidOperationException("A kölcsönzést csak akkor lehet lezárni, ha nincs már benne könyv.");
            // Amikor a RemoveBook ↓ 0-ra csökkent, rendszer már beállította a ReturnDate-et,
            // így itt nem kell újból megtenni.
        }
    }
}
