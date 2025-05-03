namespace HF9
{
    public class Planet
    {
        // Fields
        public string name;
        private List<Starship> ships;
        
        // Constructors
        public Planet(string n)
        {
            name = n;
            ships = new List<Starship>();
        }
        
        // Methods
        public void Defends(Starship h)
        {
            if (ships.Contains(h)) throw new Exception();
            ships.Add(h);
        }

        public void Leaves(Starship h)
        {
            if (!ships.Contains(h)) throw new Exception();
            ships.Remove(h);
        }

        public int ShipCount()
        {
            return ships.Count;
        }

        public double ShieldSum()
        {
            return ships.Sum(s => s.GetShield());
        }

        public (bool, double, Starship?) MaxFireP()
        {
            if (ships.Count == 0) return (false, 0, null);
            var max = ships.Max(s => s.FireP());
            var maxShip = ships.First(s => s.FireP() == max);
            return (true, max, maxShip);
        }
        
        public IEnumerable<Starship> Ships => ships;
        
    }
}

