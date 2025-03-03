namespace Base
{
    public class Dispenser
    {
        private double max;
        private double dose;
        private double act;

        public Dispenser(double a, double b)
        {
            if (!(a > 0 && b > 0))
            {
                throw new ArgumentException("Mind a két érték pozitív kell legyen!");
            }
            max = a;
            dose = b;
            act = 0.0;
        }

        public void Push()
        {
            act = Math.Max(act - dose, 0.0);
        }

        public void Fill()
        {
            act = max;
        }

        public bool IsEmpty()
        {
            return act == 0;
        }
    }
}

