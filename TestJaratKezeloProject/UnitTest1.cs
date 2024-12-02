using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class Tests
    {
        JaratKezelo jaratKezelo;

        [SetUp]
        public void Setup()
        {
            jaratKezelo = new JaratKezelo();
        }

        [Test]
        public void UjJarat_HelyesAdatokkal_NemDobErrort()
        {
            Assert.DoesNotThrow(() => jaratKezelo.UjJarat("123", "BUD", "LON", DateTime.Now));
        }

        [Test]
        public void UjJarat_NullAdattal_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.UjJarat(null, null, null, DateTime.Now));
        }

        [Test]
        public void MikorIndul_HelyesAdatokkal_HelyesIdotAdVissza()
        {
            var indulas = new DateTime(2024, 12, 1, 10, 0, 0);
            jaratKezelo.UjJarat("123", "BUD", "LON", indulas);
            jaratKezelo.Keses("123", 30); // 30 perces késés

            var expected = indulas.AddMinutes(30);
            Assert.AreEqual(expected, jaratKezelo.MikorIndul("123"));
        }

        [Test]
        public void Keses_NegativOsszeg_NegativKesesExceptiontDob()
        {
            jaratKezelo.UjJarat("123", "BUD", "LON", DateTime.Now);
            jaratKezelo.Keses("123", 20);

            Assert.Throws<NegativKesesException> (() => jaratKezelo.Keses("123", -30));
        }


        [Test]
        public void MikorIndul_NemLetezoJarat_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => jaratKezelo.MikorIndul("999"));
        }

        [Test]
        public void JaratokRepuloterrol_HelyesAdatokkal_HelyesLista()
        {
            jaratKezelo.UjJarat("123", "BUD", "LON", DateTime.Now);
            jaratKezelo.UjJarat("124", "BUD", "PAR", DateTime.Now);
            jaratKezelo.UjJarat("125", "LON", "BUD", DateTime.Now);

            var jaratok = jaratKezelo.JaratokRepuloterrol("BUD");
            CollectionAssert.AreEquivalent(new List<string> { "123", "124" }, jaratok);
        }

        [Test]
        public void JaratokRepuloterrol_UresReptel_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException> (() => jaratKezelo.JaratokRepuloterrol(""));
        }


        [Test]
        public void JaratokRepuloterrol_HelyesAdatokkal_NemDobErrort()
        {
            jaratKezelo.UjJarat("123", "BUD", "LON", DateTime.Now);
            jaratKezelo.UjJarat("124", "BUD", "LON", DateTime.Now);
            jaratKezelo.UjJarat("125", "BUD", "LON", DateTime.Now);

            Assert.DoesNotThrow(() => jaratKezelo.JaratokRepuloterrol("BUD"));
        }
    }
}