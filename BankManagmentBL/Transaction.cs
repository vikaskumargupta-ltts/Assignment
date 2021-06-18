using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagmentBL
{
    public enum TransactionStatus
    {
        Done=1,
        Pending=2,
    }
    public class Transaction
    {
        public static int Counter { get; set; } = 1000;
        public int TransactionId { get; set; } = 1;
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public double TransactionFee { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
        public double Amount { get; set; }
        public Transaction()
        {
            Counter++;
            TransactionId = Counter;
        }
    }
}
