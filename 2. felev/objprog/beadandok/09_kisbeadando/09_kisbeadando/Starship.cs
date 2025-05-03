namespace HF9
{
    public abstract class Starship
    {
        // Fields
        protected string name;
        protected int shield;
        protected int armor;
        protected int guarian;
        protected Planet? planet;
        
        // Constructors
        public Starship(string n, int pa, int pá, int ű)
        {
            name = n;
            shield = pa;
            armor = pá;
            guarian = ű;
            planet = null;
        }
        
        // Properties
        public Planet CurrentPlanet => planet;
        public int GetShield()
        {
            return shield;
        }

        // Methods
        public void StaysAtPlanet(Planet b)
        {
            if (b == null) throw new Exception();
            if (planet != null) planet.Leaves(this);
            planet = b;
            b.Defends(this);
        }

        public void LeavesPlanet()
        {
            if (planet == null) throw new Exception();
            planet.Leaves(this);
            planet = null;
        }

        public abstract double FireP();
    }
}

