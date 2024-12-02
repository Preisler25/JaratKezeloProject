using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    internal class NegativKesesException : Exception
    {
        public NegativKesesException() : base("A késés nem lehet negatív!")
        {
        }

        public NegativKesesException(string message) : base(message)
        {
        }

        public NegativKesesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
