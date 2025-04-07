namespace HF7
{
    public class Customer
    {
        private string pin;
        private int withdrawAmount;
        private List<Account> accounts;
        private Card card;
        public Customer(string pin, int withdraw)
        {
            this.pin = pin;
            this.withdrawAmount = withdraw;
            accounts = new List<Account>();
        }
        
        public void Withdrawal(ATM atm)
        {
            atm.Process(this);
        }

        public string ProvidesPIN()
        {
            return pin;
        }

        public Card ProvidesCard()
        {
            return card;
        }

        public int RequestMoney()
        {
            return withdrawAmount;
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            card = new Card(account.accNum, pin);
            account.cards.Add(card);
        }
    }
}

