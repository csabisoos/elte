namespace Library
{
    /// <summary>
    /// „Üres” állapot: a Loan._books.Count == 0.
    /// Itt még nincs hozzáadott könyv, vagy minden visszahozás után ide kerül vissza.
    /// </summary>
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

            // Mivel eddig 0 könyv volt, a most hozzáadott könyv után biztos, hogy 1 lesz,
            // így az állapot átmegy IntermediateState-be.
            _loan.Internal_AddToBooks(book);
            _loan.ChangeState(new IntermediateState(_loan));
        }

        public void RemoveBook(Book book)
        {
            // Ha üresben próbálunk eltávolítani, az invalid művelet:
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
