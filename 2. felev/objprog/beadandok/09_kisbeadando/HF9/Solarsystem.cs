namespace HF9
{
    public class Solarsystem
    {
        public List<Planet> planets;
        
        public Solarsystem()
        {
            planets = new List<Planet>();
        }

        public (bool, Starship?) MaxFireP()
        {
            var allShips = planets.SelectMany(p => p.Ships).ToList();
            if (allShips.Count == 0) return (false, null);
            var maxShip = allShips.OrderByDescending(s => s.FireP()).First();
            return (true, maxShip);
        }

        public List<Planet> Defenseless()
        {
            return planets.Where(p => p.ShipCount() == 0).ToList();
        }
    }
}

