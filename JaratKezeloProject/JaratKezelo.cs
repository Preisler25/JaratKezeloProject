using System.Dynamic;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        Dictionary<string, Jarat> jaratok = new Dictionary<string, Jarat>();

        public JaratKezelo()
        {
        }
        
        public bool JaratNemLetezik(string jaratSzam)
        {
            if (jaratok.ContainsKey(jaratSzam))
            {
                return false;
            }
            return true;
        }

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (string.IsNullOrEmpty(jaratSzam)) throw new ArgumentException("A járatszám nem lehet üres!" +  nameof(jaratSzam));
            if (string.IsNullOrEmpty(repterHonnan)) throw new ArgumentException("A reptér honnan nem lehet üres!" + nameof(repterHonnan));
            if (string.IsNullOrEmpty(repterHova)) throw new ArgumentException("A reptér hova nem lehet üres!" + nameof(repterHova));
            if (indulas == null) throw new ArgumentException("Az indulás nem lehet üres!" + nameof(indulas));

            if (!JaratNemLetezik(jaratSzam))
            {
                throw new ArgumentException("A járat már létezik!");
            }

            jaratok.Add(jaratSzam, new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
        }
        public void Keses(string jaratSzam, int keses)
        {
            if (JaratNemLetezik(jaratSzam))
            {
                throw new ArgumentException("A járat nem létezik!");
            }

            var jarat = jaratok[jaratSzam];

            if (jarat.keses + keses < 0)
            {
                throw new NegativKesesException();
            }

            jarat.keses += keses;
        }


        public DateTime MikorIndul(string jaratSzam)
        {
            if (JaratNemLetezik(jaratSzam))
            {
                throw new ArgumentException("A járat nem létezik!");
            }

            Jarat jarat = jaratok[jaratSzam];
            return jarat.indulas.AddMinutes(jarat.keses);
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            if (string.IsNullOrEmpty(repter))
            {
                throw new ArgumentException("A reptér neve nem lehet üres!");
            }

            return jaratok.Values
                          .Where(j => j.honnanRepter == repter)
                          .Select(j => j.jaratSzam)
                          .ToList();
        }

    }
}
