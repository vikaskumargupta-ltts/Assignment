using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BankManagmentBL
{
    public class AccountHolderDetails
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }

        public AccountHolderDetails(int accountNumber, string name, DateTime dateofbirth, string emailId)
        {
            AccountNumber = accountNumber;
            Name = name;
            DateOfBirth = dateofbirth;
            EmailId = emailId;
        }
    }
}
