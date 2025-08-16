using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Project
{
    internal class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } 
        public int? FromAccount { get; set; }
        public int? ToAccount { get; set; }

        public Transaction(int id, decimal amount, string type, int? fromAccount = null, int? toAccount = null)
        {
            TransactionID = id;
            Date = DateTime.Now;
            Amount = amount;
            Type = type;
            FromAccount = fromAccount;
            ToAccount = toAccount;
        }

        public  string ToString()
        {
            return $"{Date}: {Type} {Amount} (From {FromAccount} To {ToAccount})";
        }


    }
}
