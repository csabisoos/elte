namespace Library
{
    /// <summary>
    /// „Teli” állapot: a Loan._books.Count == 5.
    /// Itt már nem engedhető meg további könyv hozzáadása (Max 5).
    /// Visszahozáskor, ha 4 lesz, IntermediateState-be léptetjük át.
    /// </summary>
    public class FullState : ILoanState
    {
        private readonly Loan _loan;

        public FullState(Loan loan)
        {
            _loan = loan ?? throw new ArgumentNullException(nameof(loan));
        }

        public string StateName => "Full";

        public void AddBook(Book book)
        {
            // Ha már 5 könyv van, nem lehet további könyvet hozzátenni.
            throw new InvalidOperationException("Maximum 5 könyv lehet egy kölcsönzésben (Full állapot).");
        }

        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool removed = _loan.Internal_RemoveFromBooks(book);
            if (!removed)
                throw new InvalidOperationException("Ez a könyv nem része ennek a kölcsönzésnek.");

            // Ha most 4-re csökkent, IntermediateState-be váltunk
            if (_loan.InternalBookCount == 4)
                _loan.ChangeState(new IntermediateState(_loan));
            // Ha 0 lett volna (ugyan ritka, mert 5-ből egyszerre 5-öt nem lehet egy metódushívásban eltávolítani),
            // akkor onnan az IntermediateState.RemoveBook már EmptyState-be váltaná.
        }

        public void CloseIfEmpty()
        {
            if (_loan.InternalBookCount != 0)
                throw new InvalidOperationException("A kölcsönzést csak akkor lehet lezárni, ha nincs már benne könyv.");
            // Az utolsó könyv törlésekor a ReturnDate beállítása már megtörtént.
        }
    }
}

