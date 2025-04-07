namespace HF7
{
    public class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
        }
        
        public void OpenAccount(string number, Customer customer)
        {
            Account acc = new Account(number);
            accounts.Add(acc);
            customer.AddAccount(acc);
        }

        public void ProvidesCard(string number)
        {
            foreach (var acc in accounts)
            {
                if (acc.accNum == number)
                {
                    Card card = new Card(number, "");
                    acc.cards.Add(card);
                }
            }
        }
        
        public int GetBalance(string cardNum)
        {
            bool l;
            Account account;
            (l, account) = FindAccount(cardNum);
            if (l)
            {
                return account.GetBalance();
            }

            return -1;
        }

        public void Transaction(string cardNum, int amount)
        {
            bool l;
            Account account;
            (l, account) = FindAccount(cardNum);
            if (l)
            {
                account.Change(amount);
            }
        }
        
        public bool CheckAccount(string number)
        {
            foreach (var acc in accounts)
            {
                if (acc.accNum == number)
                {
                    return true;
                }
            }
            return false;
        }

        private (bool, Account) FindAccount(string cardNum)
        {
            foreach (var acc in accounts)
            {
                if (acc.accNum == cardNum)
                {
                    return (true, acc);
                }

                foreach (var card in acc.cards)
                {
                    if (card.cNum == cardNum)
                    {
                        return (true, acc);
                    }
                }
            }
            return (false, null);
        }
        
        
    }
}

