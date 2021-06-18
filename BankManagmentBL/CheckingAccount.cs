using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagmentBL
{
    public class CheckingAccount:Accounts
    {
        public CheckingAccount()
        {
        }

        public override double Debit(double amount, double debitedAmount)
        {
            try
            {
                if (amount >= debitedAmount && debitedAmount > 0)
                    return debitedAmount * .01;
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
