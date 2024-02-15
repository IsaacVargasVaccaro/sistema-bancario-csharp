using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_bancario_csharp.Entities.Exceptions
{
    public class DomainExceptions : ApplicationException
    {
        public DomainExceptions(string message) : base(message)
        {
        }
    }
}