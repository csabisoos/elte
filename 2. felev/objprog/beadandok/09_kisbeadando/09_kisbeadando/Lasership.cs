namespace HF9
{
    public class Lasership : Starship
    {
        public Lasership(string n, int pa, int pá, int ű)
            : base(n, pa, pá, ű) { }

        public override double FireP()
        {
            return shield;
        }
    }
}

