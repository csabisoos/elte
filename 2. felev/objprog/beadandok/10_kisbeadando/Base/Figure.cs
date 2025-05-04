namespace HF10
{
    public class Figure : Gift
    {
        public override int Pont()
        {
            return 2;
        }

        public Figure(Size size) : base(size) { }
    }
}

