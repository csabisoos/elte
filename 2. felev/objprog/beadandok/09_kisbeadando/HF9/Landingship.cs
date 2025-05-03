namespace HF9
{
    public class Landingship : Starship
    {
        public Landingship(string n, int pa, int pá, int ű)
            : base(n, pa, pá, ű) { }

        public override double FireP()
        {
            return guarian;
        }
    }
}

