namespace HF10
{
    public class Plush : Gift
    {
        public override int Pont()
        {
            return 3;
        }

        public Plush(Size size) : base(size) { }
    }
}

