namespace Library
{
    /// <summary>
    /// A FineVisitor kiszámolja az átadott könyv napi pótdíját
    /// a hosszú késés (overdueDays) és a példányszám alapján.
    /// Mivel csak ScienceBook, LiteratureBook és YouthBook létezik,
    /// ezekhez írtuk meg a Visit(...) metódusokat.
    /// </summary>
    public class FineVisitor
    {
        private readonly int _overdueDays;
        private decimal _result;

        /// <summary>
        /// Konstruktornak adjuk át, hogy hány nap a késés.
        /// </summary>
        /// <param name="overdueDays">A késés napjainak száma (ha 0, nincs pótdíj).</param>
        public FineVisitor(int overdueDays)
        {
            if (overdueDays < 0)
                throw new ArgumentOutOfRangeException(nameof(overdueDays), "A késés napjainak száma nem lehet negatív.");
            _overdueDays = overdueDays;
        }

        /// <summary>
        /// Terminál‐látnok (Visit) ScienceBook típusra.
        /// A pótdíj‐táblázatból: Természettudományos könyv (ScienceBook) esetén
        /// - ritka (példányszám < 10)  → 100
        /// - kevés (10 ≤ példányszám < 100) → 60
        /// - sok (példányszám ≥ 100) → 20
        /// </summary>
        public void Visit(ScienceBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount < 100 && book.CopyCount >= 10;
            decimal dailyMultiplier = rare ? 100m : (few ? 60m : 20m);
            _result = _overdueDays * dailyMultiplier;
        }

        /// <summary>
        /// Terminál‐látnok (Visit) LiteratureBook típusra.
        /// Pótdíj‐táblázat: Szépirodalmi könyv (LiteratureBook) esetén
        /// - ritka (példányszám < 10)  → 50
        /// - kevés (10 ≤ példányszám < 100) → 30
        /// - sok (példányszám ≥ 100) → 10
        /// </summary>
        public void Visit(LiteratureBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount < 100 && book.CopyCount >= 10;
            decimal dailyMultiplier = rare ? 50m : (few ? 30m : 10m);
            _result = _overdueDays * dailyMultiplier;
        }

        /// <summary>
        /// Terminál‐látnok (Visit) YouthBook típusra.
        /// Pótdíj‐táblázat: Ifjúsági könyv (YouthBook) esetén
        /// - ritka (példányszám < 10)  → 30
        /// - kevés (10 ≤ példányszám < 100) → 10
        /// - sok (példányszám ≥ 100) → 5
        /// </summary>
        public void Visit(YouthBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount < 100 && book.CopyCount >= 10;
            decimal dailyMultiplier = rare ? 30m : (few ? 10m : 5m);
            _result = _overdueDays * dailyMultiplier;
        }

        /// <summary>
        /// Visszaadja a legutóbb számított pótdíjat.
        /// Ezt a Visit(...) metódus hívása után olvassuk ki.
        /// </summary>
        public decimal GetResult()
        {
            return _result;
        }
    }
}

