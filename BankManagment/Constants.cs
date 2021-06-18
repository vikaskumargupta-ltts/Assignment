using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagment
{
    enum AccountType
    {
        Saving = 1,
        Checking
    }
    enum AccountOperations
    {
        CreateAccount = 1,
        AddAccountHolder,
        FundTransfer,
        CheckAccountInfo,
        CloseApplication
    }
    class Constants
    {
    }
}
