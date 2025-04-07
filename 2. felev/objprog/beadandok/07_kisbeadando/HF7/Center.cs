namespace HF7
{
    public class Center
    {
        private List<Bank> banks;
        public Center(List<Bank> banks)
        {
            this.banks = banks;
        }

        public int GetBalance(string cardNum)
        {
            bool l = true;
            Bank bank = new Bank();
            (l, bank) = FindBank(cardNum);
            if (l)
            {
                return bank.GetBalance(cardNum);
            }

            return -1;
        }

        public void Transaction(string cardNum, int amount)
        {
            bool l;
            Bank bank = new Bank();
            (l, bank) = FindBank(cardNum);
            if (l)
            {
                bank.Transaction(cardNum, amount);
            }
        }
        
        //hianyos
        private (bool, Bank) FindBank(string cardNum)
        {
            foreach (var bank in banks)
            {
                if (bank.CheckAccount(cardNum))
                {
                    return (true, bank);
                }
            }
            return (false, null);
        }
    }
}

