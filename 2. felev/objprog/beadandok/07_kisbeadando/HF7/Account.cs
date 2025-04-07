namespace HF7
{
    public class Account
    {
        public string accNum;
        private int egyenl;

        public List<Card> cards;
        
        public Account(string number)
        {
            accNum = number;
            egyenl = 0;
            cards = new List<Card>();
        }

        public int GetBalance()
        {
            return egyenl;
        }

        public void Change(int amount)
        {
            egyenl += amount;
        }
    }
}

