using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    internal class Jarat
    {
        public string jaratSzam;
        public string honnanRepter;
        public string hovaRepter;
        public DateTime indulas;
        public int keses;

        public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
        {
            this.jaratSzam = jaratSzam;
            this.honnanRepter = honnanRepter;
            this.hovaRepter = hovaRepter;
            this.indulas = indulas;
        }
    }
}
