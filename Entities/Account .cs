using System;
using sistema_bancario_csharp.Entities.Exceptions;


namespace sistema_bancario_csharp.Entities
{
    public class Account 
    {
        private int _number;
        private string _holder;
        private string _email;
        public decimal Balance { get; protected set; }

        public int Number 
        { 
            get { return _number; }
            set { _number = value; }
        }
        public string Holder
        {
             get { return _holder; }
             set { _holder = value; } 
        }
         public string Email
        {
             get { return _email; }
             set { _email = value; } 
        }
       
       public Account (int number, string holder, string email, decimal balance)
       {
                if(number < 0) 
                {
                    throw new Exception ("The account number must be greater than zero.");
                }
                if (number != (int)number)
                {
                    throw new ArgumentException("The account number must be an integer.");
                }
                
                if (holder != (string)holder)
                {
                    throw new Exception("The holder's name is invalid.");
                }
                 if (string.IsNullOrWhiteSpace(holder))
                {
                    throw new ArgumentNullException("The field cannot be blank.");
                }
                if (email != (string)email)
                {
                    throw new ArgumentException ("The email is invalid.");
                }
                if (!email.Contains("@"))
                {
                    throw new ArgumentException ("The email is invalid.");
                }
                if (string.IsNullOrWhiteSpace(email)) 
                {
                    throw new ArgumentNullException("The field cannot be blank.");
                }
                if (balance < 0)
                {
                    throw new ArgumentException ("The balance must be greater than zero.");
                }

       
        Number = number;
        Holder = holder;
        Email = email;
        Balance = balance;

       }

       public void Withdraw (decimal amount)
       {
        Balance -= amount;

        if (amount > Balance)
        {
            throw new DomainExceptions ("low balance.");
        }

       }
       public void Deposit (decimal amount)
       {
        Balance += amount;
       }

       public override string ToString()
       {
        return $"Number: {Number}, Holder: {Holder}, Email: {Email}, Balance: {Balance}";
       }
    }
}