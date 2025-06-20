using Library.Visitors;

namespace Library.Books
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

        public override decimal Accept(FineVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

