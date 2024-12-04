using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    public class NegativKesesException : Exception
    {
        public NegativKesesException() : base("Nem lehet negatív a késés!")
        {

        }
    }
}