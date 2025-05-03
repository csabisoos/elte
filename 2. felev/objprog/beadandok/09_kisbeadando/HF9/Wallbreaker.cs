namespace HF9
{
    public class Wallbreaker : Starship
    {
        public Wallbreaker(string n, int pa, int pá, int ű) 
            : base(n, pa, pá, ű) { }

        public override double FireP()
        {
            return armor / 2;
        }
    }
}

