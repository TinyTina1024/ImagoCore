using ImagoCore.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ImagoCore.Tests.Enums
{
    public class ImagoEnumerationTests
    {
        private readonly ITestOutputHelper output;

        public ImagoEnumerationTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void ImagoAttributEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoAttribut> liste = new List<ImagoAttribut>(Enumeration.GetAll<ImagoAttribut>());
            output.WriteLine("Teste Enum Attribute Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoFertigkeitEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoFertigkeit> liste = new List<ImagoFertigkeit>(Enumeration.GetAll<ImagoFertigkeit>());
            output.WriteLine("Teste Enum Fertigkeiten Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoFertigkeitsKategorieEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoFertigkeitsKategorie> liste = new List<ImagoFertigkeitsKategorie>(Enumeration.GetAll<ImagoFertigkeitsKategorie>());
            output.WriteLine("Teste Enum Fertigkeitskategorien Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoKoerperTeilEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoKoerperTeil> liste = new List<ImagoKoerperTeil>(Enumeration.GetAll<ImagoKoerperTeil>());
            output.WriteLine("Teste Enum Körperteile Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoNichtSteigerbareFertigkeitenEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoNichtSteigerbareFertigkeit> liste = new List<ImagoNichtSteigerbareFertigkeit>(Enumeration.GetAll<ImagoNichtSteigerbareFertigkeit>());
            output.WriteLine("Teste Enum Nichtsteigerbare Fertigkeiten Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoKoerperTeileEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoKoerperTeil> liste = new List<ImagoKoerperTeil>(Enumeration.GetAll<ImagoKoerperTeil>());
            output.WriteLine("Teste Enum Körperteile Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoRasseEnumerationInitializes_NoNumberDoubled()
        {
            List<ImagoRasse> liste = new List<ImagoRasse>(Enumeration.GetAll<ImagoRasse>());
            output.WriteLine("Teste Enum Rassen Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        [Fact]
        public void ImagoKoerperTeilZustaendeInitializes_NoNumberDoubled()
        {
            List<ImagoKoerperTeil> liste = new List<ImagoKoerperTeil>(Enumeration.GetAll<ImagoKoerperTeil>());
            output.WriteLine("Teste Enum Körperteilzustände Value : Name");
            AssertEnumerationForDuplicates(liste);
        }

        private void AssertEnumerationForDuplicates<T>(List<T> input) where T : Enumeration
        {
            var temp = new List<T>(input);
            temp.Sort((a, b) => a.Value.CompareTo(b.Value));

            bool hit = false;
            for (int i = 0; i < temp.Count(); i++)
            {
                output.WriteLine("{0:00}: {1}", i, temp[i].ToString());
                if (i != 0)
                {
                    if (temp[i - 1].Value == temp[i].Value)
                    {
                        hit = true;
                        break;
                    }
                }
            }

            Assert.False(hit);
        }
    }

    //public class EnumerationInitializeTestData: IEnumerable<object[]>
    //{
    //    public IEnumerator<object[]> GetEnumerator()
    //    {
    //        yield return 
    //    }
    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    // }
}

