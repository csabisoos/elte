namespace HF7
{
    public class ATM
    {
        public string telephely;
        private Center center;

        public ATM(string telephely, Center center)
        {
            this.telephely = telephely;
            this.center = center;
        }
        
        public void Process(Customer customer)
        {
            Card card = customer.ProvidesCard();
            if (card.CheckPIN(customer.ProvidesPIN()))
            {
                int a = customer.RequestMoney();
                if (center.GetBalance(card.cNum)>=a)
                {
                    center.Transaction(card.cNum, -a); // pénzt kiad
                }
            }
        }
    }
}

