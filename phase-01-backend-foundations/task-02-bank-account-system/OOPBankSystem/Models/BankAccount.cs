using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OOPBankSystem.Models
{

    public enum AccountType
    {
        Savings,
        Current
    }
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public Customer Customer { get; set; }
        public decimal Balance { get; private set; }
        public AccountType AccountType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public BankAccount()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }


        public bool Withdraw(decimal money)
        {
            if (money > Balance || money < 0) return false;
            Balance -= money;

            Transactions.Add(new Transaction
            {
                Amount = money,
                BalanceAfterTransaction = Balance,
                TransactionDate = DateTime.Now,
                TransactionType = TransType.Withdrawal,

            });

            return true;
        }
        public decimal Deposit(decimal money)
        {
            if (money <= 0) throw new ArgumentException("amount must be positive");
            Transactions.Add(new Transaction
            {
                Amount = money,
                BalanceAfterTransaction = Balance,
                TransactionDate = DateTime.Now,
                TransactionType = TransType.Deposit,

            });
            return Balance += money;
        }
    }
}
