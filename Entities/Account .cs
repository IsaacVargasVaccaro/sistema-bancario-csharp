using System;


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
        Number = number;
        Holder = holder;
        Email = email;
        Balance = balance;

       }

       public void Withdraw (decimal amount)
       {
        Balance -= amount;
       }
       public void Deposit (decimal amount)
       {
        Balance += amount;
       }

       public virtual string ToString()
       {
        return Number 
        + " , " 
        + Holder 
        + " , "
        + Email
        + " , R$ "
        + Balance;
       }
    }
}