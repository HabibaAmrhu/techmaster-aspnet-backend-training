using OOPBankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPBankSystem.Services
{
    internal class BankService
    {
        private List<BankAccount> _accounts { get; set; } = new List<BankAccount>();


        public void CreateAccount(string name, string email, string phone, decimal initialBalance)
        {
            int newId = _accounts.Count + 1;

            int accNo = 1000 + newId;
            if (_accounts.Any(a => a.AccountNumber == accNo))
            {
                System.Console.WriteLine("Error: Account number already exists.");
                return;
            }
            Customer customer = new Customer
            {
                CustomerId = newId,
                FullName = name,
                Email = email,
                Phone = phone
            };

            BankAccount newAcc = new BankAccount
            {
                AccountNumber = accNo,
                Customer = customer,
            };


            newAcc.Deposit(initialBalance);
            _accounts.Add(newAcc);
            System.Console.WriteLine($"Account created successfully, account number : {accNo}");
        }

        public BankAccount GetAccountById(int accNo)
        {
            if (!_accounts.Any(n => n.AccountNumber == accNo)) { }
            return _accounts.FirstOrDefault(n => n.AccountNumber == accNo);
        }

        public List<BankAccount> GetAccounts() { return _accounts; }


        public bool Trasfer(int from , int to , decimal amount)
        {
            var fromAcc = GetAccountById(from);
            if (fromAcc == null) { return false; }
            var toAcc = GetAccountById(to);
            if (toAcc == null) {return false; }
            if(fromAcc.Balance >= amount && from != to)
            {
                fromAcc.Withdraw(amount);
                toAcc.Deposit(amount);
                return true;
            }
            return false;
        }

    }
}
