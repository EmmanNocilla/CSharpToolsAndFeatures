using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSample
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        public Transaction(Guid transactionId, decimal amount, DateTime date, string sender, string receiver)
        {
            TransactionId = transactionId;
            Amount = amount;
            Date = date;
            Sender = sender;
            Receiver = receiver;
        }

        // For value-based equality, you'd need to override Equals, GetHashCode, etc.
    }
}
