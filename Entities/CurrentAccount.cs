using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_bancario_csharp.Entities
{
    public sealed class CurrentAccount : Account
    {
        private decimal _loanLimit;

        public decimal LoanLimit 
        { 
            get { return _loanLimit; }
            set {_loanLimit = value; }
        }

        public CurrentAccount (int number, string holder, string email, decimal balance, decimal loanLimit)
        : base (number, holder, email, balance) 
        {
            LoanLimit = loanLimit;
        }

        public void Loan (decimal amount)
        {
            if (amount <= LoanLimit) 
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Value exceeded");
            }
        }
        public override string ToString()
        {
            return $"Number: {Number}, Holder: {Holder}, Email: {Email}, Balance: {Balance}, Loan limit: {LoanLimit}";
        }
    }
}