namespace HF7
{
    public class Card
    {
        public string cNum;
        private string PIN;

        public Card(string number, string pin)
        {
            cNum = number;
            PIN = pin;
        }
        public void SetPIN(string pin)
        {
            PIN = pin;
        }

        public bool CheckPIN(string pin)
        {
            return PIN == pin;
        }
    }
}

