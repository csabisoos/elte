public class Book
{
    // --- Alapadatok ---
    public string Title     { get; }
    public string Author    { get; }
    public string Publisher { get; }
    public string ISBN      { get; }  // Egyedi azonosító

    // --- Kategorizálás a pótdíjhoz ---
    public BookGenre Genre  { get; }
    public int CopyCount    { get; private set; }   // Összes példányszám a könyvtárban

    // --- Konstruktor ---
    public Book(
        string title,
        string author,
        string publisher,
        string isbn,
        BookGenre genre,
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
        Genre     = genre;
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

    // --- További segédmetódusok ---
    public override string ToString()
        => $"{Title} by {Author} (ISBN: {ISBN}, Genre: {Genre}, Copies: {CopyCount})";
}
