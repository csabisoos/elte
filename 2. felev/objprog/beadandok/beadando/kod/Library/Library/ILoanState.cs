namespace Library
{
    /// <summary>
    /// Interfész a Loan állapotainak kezeléséhez (State minta).
    /// A metódusok a Loan.AddBook(…) és Loan.RemoveBook(…) logikáját
    /// hívják meg, de az aktuális állapot szabályai szerint.
    /// </summary>
    public interface ILoanState
    {
        /// <summary>
        /// Hozzáad egy könyvet a loan-hoz (követi az aktuális állapot szabályait).
        /// </summary>
        /// <param name="book">A hozzáadni kívánt könyv.</param>
        void AddBook(Book book);

        /// <summary>
        /// Eltávolít egy könyvet a loan-ból (részleges visszahozás).
        /// </summary>
        /// <param name="book">A visszahozott könyv.</param>
        void RemoveBook(Book book);

        /// <summary>
        /// Ha a könyvlista (Loan._books) üresre csökken, lezárjuk a Loan-t.
        /// </summary>
        void CloseIfEmpty();

        /// <summary>
        /// Visszaadja az aktuális állapot nevéből képzett stringet (opcionális,
        /// tájékoztatásul használható a diagnosztikában).
        /// </summary>
        string StateName { get; }
    }
}

