using System.ComponentModel.DataAnnotations;

namespace HF10
{
    public class AmPark
    {
        // Fields
        private List<TargetShot> targetShots;
        private List<Guest> guests;
        
        // Constructors
        public AmPark(List<TargetShot> c)
        {
            if (c.Count < 2) throw new Exception();
            targetShots = c;
            guests = new List<Guest>();
        }
        
        // Methods
        public void Receives(Guest v)
        {
            if (guests.Contains(v)) throw new Exception();
            guests.Add(v);
        }

        public string Best(TargetShot c)
        {
            if (guests.Count == 0) throw new Exception();
            int max = 0;
            Guest winner = guests[0];
            max = guests[0].Result(c);
            for (int i = 1; i < guests.Count; i++)
            {
                if (guests[i].Result(c) > max)
                {
                    winner = guests[i];
                    max = guests[i].Result(c);
                }
            }
            if (max == 0) throw new Exception();
            return winner.getName();
        }
    }
}

