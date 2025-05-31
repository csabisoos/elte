namespace Library
{
    /// <summary>
    /// Természettudományos könyv, a Visitor-mintához implementálja az Accept metódust.
    /// </summary>
    public class ScienceBook : Book
    {
        public ScienceBook(
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

