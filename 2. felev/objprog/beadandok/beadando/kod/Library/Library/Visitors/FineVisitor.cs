using Library.Books;

namespace Library.Visitors
{
    public class FineVisitor
    {
        private readonly int _overdueDays;
        //private decimal _result;
        
        public FineVisitor(int overdueDays)
        {
            if (overdueDays < 0)
                throw new ArgumentOutOfRangeException(nameof(overdueDays), "A késés napjainak száma nem lehet negatív.");
            _overdueDays = overdueDays;
        }
        
        public decimal Visit(ScienceBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount < 100 && book.CopyCount >= 10;
            decimal dailyMultiplier = rare ? 100m : (few ? 60m : 20m);
            return _overdueDays * dailyMultiplier;
        }
        
        public decimal Visit(LiteratureBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount >= 10 && book.CopyCount < 100;
            decimal dailyMultiplier = rare ? 50m : (few ? 30m : 10m);
            return _overdueDays * dailyMultiplier;
        }
        
        public decimal Visit(YouthBook book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            bool rare = book.CopyCount < 10;
            bool few  = book.CopyCount < 100 && book.CopyCount >= 10;
            decimal dailyMultiplier = rare ? 30m : (few ? 10m : 5m);
            return _overdueDays * dailyMultiplier;
        }
        
        /*public decimal GetResult()
        {
            return _result;
        }*/
    }
}

