using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagmentBL
{
    public abstract class Accounts
    {
        public Accounts()
        {
            Counter++;
            AccountNumber = Counter;
        }

        public static int Counter = 800001000;
        public int AccountNumber { get; set; }
        public List<AccountHolderDetails> AccountHolders { get; set; }
        public DateTime AccountOpeningDate { get; set; } = DateTime.Now;
        public double BalanceAmount { get; set; }
        public List<Transaction> ListOfTransactions { get; set; }

        public abstract double Debit(double amount, double debitedAmount);
        public void Credit(double CreditedAmount)
        {
            // Not Implemented
        }
        public void CalculateBalanceAmount()
        {
            // Not Implemented
        }
    }
}
