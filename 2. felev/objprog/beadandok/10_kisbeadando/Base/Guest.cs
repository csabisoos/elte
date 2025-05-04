namespace HF10
{
    public class Guest
    {
        // Fields
        private string name { get; }
        private List<Gift> prizes;
        
        // Properties
        public string getName()
        {
            return name;
        }
        
        // Constructors
        public Guest(string n)
        {
            name = n;
            prizes = new List<Gift>();
        }
        
        // Methods
        public void Wins(Gift a)
        {
            if (!a.GetTargetShot().GetGifts().Contains(a)) throw new Exception();
            a.GetTargetShot().GetGifts().Remove(a);
            prizes.Add(a);
        }

        public int Result(TargetShot c)
        {
            return prizes.Sum(e => e.GetTargetShot() == c ? e.Value() : 0);
        }
    }
}

