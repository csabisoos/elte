public class Book
{
    // --- Alapadatok ---
    public string Title       { get; }
    public string Author      { get; }
    public string Publisher   { get; }
    public int ISBN        { get; }     // Egyedi azonosító

    // --- Kategorizálás a pótdíjhoz ---
    public BookGenre Genre    { get; }
    public int CopyCount      { get; private set; }   // Összes példányszám a könyvtárban

    // --- Konstruktor ---
    public Book(string title,
                string author,
                string publisher,
                int isbn,
                BookGenre genre,
                int copyCount)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            throw new ArgumentException("ISBN nem lehet üres.", nameof(isbn));
        if (copyCount < 0)
            throw new ArgumentOutOfRangeException(nameof(copyCount), "Példányszám nem lehet negatív.");

        Title      = title;
        Author     = author;
        Publisher  = publisher;
        ISBN       = isbn;
        Genre      = genre;
        CopyCount  = copyCount;
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
        if (amount <= 0 || amount > CopyCount)
            throw new ArgumentOutOfRangeException(nameof(amount), "Csökkenteni csak létező példányszámból lehet.");
        CopyCount -= amount;
    }

    // --- További segédmetódusok ---
    public override string ToString()
        => $"{Title} by {Author} (ISBN: {ISBN}, Genre: {Genre}, Copies: {CopyCount})";
}
