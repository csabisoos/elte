namespace Library
{
    public class LiteratureBook : Book
    {
        public LiteratureBook(
            string title,
            string author,
            string publisher,
            string isbn,
            int copyCount)
            : base(title, author, publisher, isbn, copyCount)
        {
        }

        public override void Accept(FineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

