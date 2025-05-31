namespace Library
{
    /// <summary>
    /// Absztrakt osztály, ami a közös adatokat (Title, Author, ISBN, CopyCount) tartalmazza,
    /// valamint az Accept(FineVisitor) metódust deklarálja Visitor-mintához.
    /// </summary>
    public abstract class Book
    {
        // --- Alapadatok ---
        public string Title     { get; }
        public string Author    { get; }
        public string Publisher { get; }
        public string ISBN      { get; }  // Egyedi azonosító
        public int    CopyCount { get; private set; }   // Összes példányszám a könyvtárban

        /// <summary>
        /// Konstruktor az általános adatokhoz (műfaj nélkül).
        /// A leszármazottak a saját konstruktorukban hívják meg.
        /// </summary>
        protected Book(
            string title,
            string author,
            string publisher,
            string isbn,
            int copyCount)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title nem lehet üres.", nameof(title));
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author nem lehet üres.", nameof(author));
            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("Publisher nem lehet üres.", nameof(publisher));
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN nem lehet üres.", nameof(isbn));
            if (copyCount < 0)
                throw new ArgumentOutOfRangeException(nameof(copyCount), "Példányszám nem lehet negatív.");

            Title     = title;
            Author    = author;
            Publisher = publisher;
            ISBN      = isbn;
            CopyCount = copyCount;
        }

        // --- Példányszám-kezelés (pl. beszerzés/leszelejtezés) ---
        public void IncreaseCopies(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Növelés csak pozitív értékkel lehetséges.");
            CopyCount += amount;
        }

        public void DecreaseCopies(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Csökkenteni csak pozitív értékkel lehet.");
            if (amount > CopyCount)
                throw new ArgumentOutOfRangeException(nameof(amount), "Csökkenteni csak a meglévő példányszámból lehet.");
            CopyCount -= amount;
        }

        /// <summary>
        /// Visitor belépési pont: minden leszármazott típus ezt valósítja meg,
        /// és hívja tovább a FineVisitor megfelelő Visit(...) metódusát.
        /// </summary>
        public abstract void Accept(FineVisitor visitor);

        public override string ToString()
            => $"{Title} by {Author} (ISBN: {ISBN}, Copies: {CopyCount})";
    }
}
