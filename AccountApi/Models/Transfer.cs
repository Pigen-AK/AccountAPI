using System;

namespace AccountApi.Models
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public string SourceAccountNumber { get; set; }
        public string DestinationAccountNumber { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TransferDate { get; set; }
        public string Description { get; set; }

        public Transfer(string sourceAccountNumber, string destinationAccountNumber, double amount, string description)
        {
            Id = Guid.NewGuid();
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            Currency = "DKK";
            TransferDate = DateTime.Now;
            Description = description;
        }
    }
}