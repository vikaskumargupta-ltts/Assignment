using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankManagmentBL;

namespace BankManagment
{
    class Program
    {
        static List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        static List<CheckingAccount> checkingAccounts = new List<CheckingAccount>();
        static void Main(string[] args)
        {
            try
            {
                BankOperations();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void BankOperations()
        {
            try
            {
                StringBuilder startOpertaion = new StringBuilder();
                startOpertaion.Append("Please Enter What operation you want to perform:" + "\n");
                startOpertaion.Append("Create an account press: " + (int)AccountOperations.CreateAccount + "\n");
                startOpertaion.Append("Add Another account holder in existing account press: " + (int)AccountOperations.AddAccountHolder + "\n");
                startOpertaion.Append("Fund transfer press: " + (int)AccountOperations.FundTransfer + "\n");
                startOpertaion.Append("View Account Info: " + (int)AccountOperations.CheckAccountInfo + "\n");
                startOpertaion.Append("For close application: " + (int)AccountOperations.CloseApplication + "\n");
                Console.WriteLine(startOpertaion);
                int selectOption = Convert.ToInt32(Console.ReadLine());
                switch (selectOption)
                {
                    case (int)AccountOperations.CreateAccount:
                        CreateBankAccount();
                        break;
                    case (int)AccountOperations.AddAccountHolder:
                        AddNewAccountHolder();
                        break;
                    case (int)AccountOperations.FundTransfer:
                        Transaction();
                        break;
                    case (int)AccountOperations.CheckAccountInfo:
                        CheckAccountInfo();
                        break;
                    case (int)AccountOperations.CloseApplication:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select an appropriate option.");
                        break;
                }
                BankOperations();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void CreateBankAccount()
        {
            try
            {
                StringBuilder startOpertaion = new StringBuilder();
                startOpertaion.Append("Please Enter What operation you want to perform" + "\n");
                startOpertaion.Append("Create saving account press " + (int)AccountType.Saving + "\n");
                startOpertaion.Append("Create checking account press " + (int)AccountType.Checking + "\n");
                Console.WriteLine(startOpertaion);

                int accountType = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Your Name to create an account");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Your date of birth in dd-yy-mmmm format");
                string dateofBirth = Console.ReadLine();
                Console.WriteLine("Enter Your email  id");
                string emailId = Console.ReadLine();
                Console.WriteLine("Amount to be credit");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (accountType == (int)AccountType.Saving)
                {
                    SavingsAccount savingAccount = new SavingsAccount();
                    savingAccount.BalanceAmount = amount;
                    savingAccount.AccountOpeningDate = DateTime.Now;
                    savingAccount.AccountHolders = new List<AccountHolderDetails>()
                    {
                        new AccountHolderDetails(savingAccount.AccountNumber, name, Convert.ToDateTime(dateofBirth), emailId),
                    };
                    savingsAccounts.Add(savingAccount);
                }
                else if (accountType == (int)AccountType.Checking)
                {
                    CheckingAccount checkingAccount = new CheckingAccount();
                    checkingAccount.BalanceAmount = amount;
                    checkingAccount.AccountOpeningDate = DateTime.Now;
                    checkingAccount.AccountHolders = new List<AccountHolderDetails>()
                    {
                        new AccountHolderDetails(checkingAccount.AccountNumber, name, Convert.ToDateTime(dateofBirth),
                            emailId),
                    };
                    checkingAccounts.Add(checkingAccount);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void CheckAccountInfo()
        {
            StringBuilder startOpertaion = new StringBuilder();
            startOpertaion.Append("Please choose your account type" + "\n");
            startOpertaion.Append("Saving account press 1" + "\n");
            startOpertaion.Append("Checking account press 2" + "\n");
            Console.WriteLine(startOpertaion);

            int accountType = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter account number to check info");
            int accountNumber = Convert.ToInt32(Console.ReadLine());


            if (accountType == (int)AccountType.Saving)
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                savingsAccount = savingsAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                Console.WriteLine("Account Number: " + savingsAccount.AccountNumber + " Account Openening Date: " + savingsAccount.AccountOpeningDate + " Balance Amount: " + savingsAccount.BalanceAmount);
                foreach (var accountAccountHolder in savingsAccount.AccountHolders)
                {
                    Console.WriteLine("Account holder name: " + accountAccountHolder.Name + " Date of Birth: " + accountAccountHolder.DateOfBirth + " Email Id" + accountAccountHolder.EmailId);
                }
                foreach (var listOfTransaction in savingsAccount.ListOfTransactions)
                {
                    Console.WriteLine("Transaction Id : " + listOfTransaction.TransactionId + " Transaction Date: " + listOfTransaction.TransactionDate + " From: " + listOfTransaction.FromAccount + " TO: " + listOfTransaction.ToAccount
                                      + " Debited Amount: " + listOfTransaction.Amount + " Transaction Fee: " + listOfTransaction.TransactionFee + " Status: " + listOfTransaction.Status);
                }
            }
            else if (accountType == (int)AccountType.Checking)
            {

            }
        }
        public static void Transaction()
        {
            try
            {
                StringBuilder startOpertaion = new StringBuilder();
                startOpertaion.Append("Please choose your account type" + "\n");
                startOpertaion.Append("Saving account press 1" + "\n");
                startOpertaion.Append("Checking account press 2" + "\n");
                Console.WriteLine(startOpertaion);

                int accountType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Transfer From Account");
                int fromAccount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Transfer To Account");
                int toAccount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Amount");
                double amount = Convert.ToDouble(Console.ReadLine());
                if (accountType == (int)AccountType.Saving)
                {
                    SavingsAccount savingsAccount = savingsAccounts.FirstOrDefault(x => x.AccountNumber == fromAccount);
                    if (savingsAccount != null)
                    {
                        double getDebitCharge = savingsAccount.Debit(savingsAccount.BalanceAmount, amount);
                        savingsAccount.BalanceAmount = savingsAccount.BalanceAmount - (amount + getDebitCharge);
                        savingsAccount.ListOfTransactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                FromAccount = fromAccount,
                                ToAccount = toAccount,
                                Amount = amount,
                                Status = TransactionStatus.Done,
                                TransactionDate = DateTime.Now,
                                TransactionFee = getDebitCharge
                            }
                        };
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                }
                else if (accountType == (int)AccountType.Checking)
                {
                    CheckingAccount checkingAccount = checkingAccounts.FirstOrDefault(x => x.AccountNumber == fromAccount);
                    if (checkingAccount != null)
                    {
                        double getDebitCharge = checkingAccount.Debit(checkingAccount.BalanceAmount, amount);
                        checkingAccount.BalanceAmount = checkingAccount.BalanceAmount - (amount + getDebitCharge);
                        checkingAccount.ListOfTransactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                FromAccount = fromAccount,
                                ToAccount = toAccount,
                                Amount = amount,
                                Status = TransactionStatus.Done,
                                TransactionDate = DateTime.Now,
                                TransactionFee = getDebitCharge
                            }
                        };
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static void AddNewAccountHolder()
        {
            try
            {
                StringBuilder startOpertaion = new StringBuilder();
                startOpertaion.Append("Please choose your account type:" + "\n");
                startOpertaion.Append("Saving account press: " + (int)AccountType.Saving + "\n");
                startOpertaion.Append("Checking account press: " + (int)AccountType.Checking + "\n");
                Console.WriteLine(startOpertaion);

                int accountType = Convert.ToInt32(Console.ReadLine());
                AddNewMember(accountType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void AddNewMember(int accountType)
        {
            try
            {
                Console.WriteLine("Enter account number where you want to add new account holder");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your Name to create an account");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Your date of birth in dd-yy-mmmm format");
                string dateofBirth = Console.ReadLine();
                Console.WriteLine("Enter Your email  id");
                string emailId = Console.ReadLine();

                if ((int)AccountType.Saving == accountType)
                {
                    SavingsAccount savingAccount = savingsAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                    if (savingAccount != null)
                        savingAccount.AccountHolders.Add(new AccountHolderDetails(accountNumber, name, Convert.ToDateTime(dateofBirth), emailId));
                    else
                        Console.WriteLine("Account does not exist.");
                }
                else if ((int)AccountType.Checking == accountType)
                {
                    CheckingAccount checkingAccount = checkingAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                    if (checkingAccount != null)
                        checkingAccount.AccountHolders.Add(new AccountHolderDetails(accountNumber, name, Convert.ToDateTime(dateofBirth), emailId));
                    else
                        Console.WriteLine("Account does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}