using Microsoft.Extensions.Primitives;
using System;
using System.Text;

namespace AccountApi.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public string RegistrationNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; } 
        public double InterestRate { get; set; }
        public DateTime CreatedOn { get; set; }

        public Account(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = 10000.00;
            Currency = GetCurrency();
            RegistrationNumber = GenerateRandomNumber(4);
            AccountNumber = GenerateRandomNumber(10);
            Iban = GenerateRandomIban();
            InterestRate = 0.00;
            CreatedOn = DateTime.Now;
        }

        private string GetCurrency()
        {
            string[] currencies = { "DKK" };

            return currencies[0];
        }

        private string GenerateRandomNumber(int digits)
        {
            Random random = new Random();

            string accountNumber = random.Next(1, 10).ToString();

            for (int i = 1; i < digits; i++)
            {
                accountNumber += random.Next(0, 10).ToString();
            }

            return accountNumber;
        }

        private string GenerateRandomIban()
        {
            Random random = new Random();

            string iban = "DK";

            for (int i = 1; i < 6; i++)
            {
                iban += random.Next(0, 10).ToString();
            }

            return iban += AccountNumber;
        }

        public void Insert(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount to insert must be greater than zero.");

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount to Withdraw must be greater than zero.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }
    }
}
