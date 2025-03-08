namespace HF3
{
    public class Diag
    {
        private double[] x;

        public Diag(int n)
        {
            if (n < 0) throw new ArgumentException("Matrix size must be at least 1.");
            x = new double[n];
        }

        public double Get(int i, int j)
        {
            if (i < 0 || i >= x.Length || j < 0 || j >= x.Length)
                throw new IndexOutOfRangeException("Invalid index.");
            return (i == j) ? x[i] : 0.0;
        }

        public void Set(int i, int j, double e)
        {
            if (i < 0 || i >= x.Length || j < 0 || j >= x.Length)
                throw new IndexOutOfRangeException("Invalid index.");
            if (i == j)
                x[i] = e;
            else if (e != 0.0)
                throw new ArgumentException("Non-diagonal elements must be zero.");
        }

        public static Diag operator +(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new ArgumentException("Matrix size must match.");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < c.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }

            return c;
        }

        public static Diag operator *(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new ArgumentException("Matrix size must match.");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < c.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }

            return c;
        }

        public static Diag Add(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new ArgumentException("Matrix size must match.");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < c.x.Length; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }

            return c;
        }

        public static Diag Multiply(Diag a, Diag b)
        {
            if (a.x.Length != b.x.Length)
                throw new ArgumentException("Matrix size must match.");
            Diag c = new Diag(a.x.Length);
            for (int i = 0; i < c.x.Length; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }

            return c;
        }
    }
}

