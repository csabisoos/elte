namespace HF10
{
    public class Ball : Gift
    {
        public override int Pont()
        {
            return 1;
        }

        public Ball(Size size) : base(size) { }
    }
}

