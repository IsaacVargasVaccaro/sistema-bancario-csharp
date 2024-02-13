using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_bancario_csharp.Entities
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount (int number, string holder, string email, decimal balance) 
        : base (number, holder, email, balance)
        {

        }

        public sealed override string ToString()
        {
            return base.ToString();
        }

    }
}