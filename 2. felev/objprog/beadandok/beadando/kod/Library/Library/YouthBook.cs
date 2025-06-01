namespace Library
{
    public class YouthBook : Book
    {
        public YouthBook(
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

