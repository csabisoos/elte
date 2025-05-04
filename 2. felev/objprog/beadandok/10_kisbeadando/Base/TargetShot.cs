namespace HF10
{
    public class TargetShot
    {
        // Fields
        private string place;
        private List<Gift> gifts { get; }

        // Properties
        public List<Gift> GetGifts()
        {
            return gifts;
        }

        // Methods
        public TargetShot(string place)
        {
            this.place = place;
            gifts = new List<Gift>();
        }

        public void Shows(Gift a)
        {
            if (a.GetTargetShot() != null) throw new Exception();
            a.SetTargetShot(this);
            gifts.Add(a);
        }
    }
}

