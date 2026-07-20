using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBankSystem.Models
{
    public enum TransType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public TransType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
    }
}
