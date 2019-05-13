using ImagoCore.Models;
using ImagoCore.Models.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ImagoCore.Tests.Models.Strategies
{
    public class FertigkeitVeraendernRegelnTests
    {
        [Fact]
        public void GetSteigerungsKosten_FertigkeitIsFertigkeit_GetImagoInt()
        {
            var random = new Random().Next(0, 101);
            SteigerbareFertigkeitBase fertigkeit = new Fertigkeit() { SteigerungsWert = random };
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);
            Assert.Contains(result, FertigkeitVeraendernRegeln.ImagoFolge);
        }

        [Fact]
        public void GetSteigerungsKosten_FertigkeitIsAttribut_GetImagoInt()
        {
            var random = new Random().Next(0, 101);
            SteigerbareFertigkeitBase fertigkeit = new Attribut() { SteigerungsWert = random };
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            Assert.Contains(result, FertigkeitVeraendernRegeln.ImagoFolge);

        }

        [Fact]
        public void GetSteigerungsKosten_FertigkeitIsFertigkeitsKategorie_GetImagoInt()
        {
            SteigerbareFertigkeitBase fertigkeit = new FertigkeitsKategorie();
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            Assert.Contains(result, FertigkeitVeraendernRegeln.ImagoFolge);
        }



        [Theory]
        [ClassData(typeof(FertigkeitSteigernKostenTestData))]
        public void GetSteigernKosten_FertigkeitIsFertigkeit(int aktuellerSteigerungsWert, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new Fertigkeit() { SteigerungsWert = aktuellerSteigerungsWert };
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitReduzierenKostenTestData))]
        public void GetReduzierenKosten_FertigkeitIsFertigkeit(int aktuellerSteigerungsWert, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new Fertigkeit() { SteigerungsWert = aktuellerSteigerungsWert };
            var result = FertigkeitVeraendernRegeln.GetReduzierenKosten(fertigkeit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(AttributSteigernKostenTestData))]
        public void GetSteigernKostenAttribut_FertigkeitIsAttribut(int aktuellerNw, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new Attribut() { SteigerungsWert = aktuellerNw };
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(AttributReduzierenKostenTestData))]
        public void GetReduzierenKosten_FertigkeitIsAttribut(int aktuellerNw, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new Attribut() { SteigerungsWert = aktuellerNw };
            var result = FertigkeitVeraendernRegeln.GetReduzierenKosten(fertigkeit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitsKategorieSteigernKostenTestData))]
        public void GetSteigernKostenAttribut_FertigkeitIsFertigkeitsKategorie(int aktuellerSteigerungsWert, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new FertigkeitsKategorie() { SteigerungsWert = aktuellerSteigerungsWert };
            var result = FertigkeitVeraendernRegeln.GetSteigernKosten(fertigkeit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitsKategorieReduzierenKostenTestData))]
        public void GetReduzierenKosten_FertigkeitIsFertigkeitsKategorie(int aktuellerSteigerungsWert, int expected)
        {
            SteigerbareFertigkeitBase fertigkeit = new FertigkeitsKategorie() { SteigerungsWert = aktuellerSteigerungsWert };
            var result = FertigkeitVeraendernRegeln.GetReduzierenKosten(fertigkeit);

            Assert.Equal(expected, result);
        }
    }

    public class AttributReduzierenKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i == 0)
                    yield return new object[] { i, 0 };
                if (1 <= i && i <= 40)
                    yield return new object[] { i, 2 };
                if (41 <= i && i <= 50)
                    yield return new object[] { i, 3 };
                if (51 <= i && i <= 60)
                    yield return new object[] { i, 5 };
                if (61 <= i && i <= 70)
                    yield return new object[] { i, 8 };
                if (71 <= i && i <= 80)
                    yield return new object[] { i, 12 };
                if (81 <= i && i <= 90)
                    yield return new object[] { i, 17 };
                if (91 <= i)
                    yield return new object[] { i, 23 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class AttributSteigernKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 99; i++)
            {
                if (0 <= i && i <= 39)
                    yield return new object[] { i, 2 };
                if (40 <= i && i <= 49)
                    yield return new object[] { i, 3 };
                if (50 <= i && i <= 59)
                    yield return new object[] { i, 5 };
                if (60 <= i && i <= 69)
                    yield return new object[] { i, 8 };
                if (70 <= i && i <= 79)
                    yield return new object[] { i, 12 };
                if (80 <= i && i <= 89)
                    yield return new object[] { i, 17 };
                if (90 <= i)
                    yield return new object[] { i, 23 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FertigkeitSteigernKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 14)
                    yield return new object[] { i, 2 };
                if (15 <= i && i <= 29)
                    yield return new object[] { i, 3 };
                if (30 <= i && i <= 44)
                    yield return new object[] { i, 5 };
                if (45 <= i && i <= 59)
                    yield return new object[] { i, 8 };
                if (60 <= i && i <= 74)
                    yield return new object[] { i, 12 };
                if (75 <= i && i <= 89)
                    yield return new object[] { i, 17 };
                if (90 <= i)
                    yield return new object[] { i, 23 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FertigkeitReduzierenKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i == 0)
                    yield return new object[] { i, 0 };

                if (0 < i && i <= 15)
                    yield return new object[] { i, 2 };
                if (16 <= i && i <= 30)
                    yield return new object[] { i, 3 };
                if (31 <= i && i <= 45)
                    yield return new object[] { i, 5 };
                if (46 <= i && i <= 60)
                    yield return new object[] { i, 8 };
                if (61 <= i && i <= 75)
                    yield return new object[] { i, 12 };
                if (76 <= i && i <= 90)
                    yield return new object[] { i, 17 };
                if (91 <= i)
                    yield return new object[] { i, 23 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FertigkeitsKategorieSteigernKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 39; i++)
            {
                if(0 <= i && i <= 4)
                    yield return new object[] { i, 5 };
                if (5 <= i && i <= 9)
                    yield return new object[] { i, 8 };
                if (10 <= i && i <= 14)
                    yield return new object[] { i, 12 };
                if (15 <= i && i <= 19)
                    yield return new object[] { i, 17};
                if (20 <= i && i <= 24)
                    yield return new object[] { i, 23 };
                if (25 <= i && i <= 29)
                    yield return new object[] { i, 30 };
                if (30 <= i && i <= 34)
                    yield return new object[] { i, 38 };
                if (35 <= i && i <= 39 )
                    yield return new object[] { i, 47 };
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FertigkeitsKategorieReduzierenKostenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 40; i++)
            {
                if (i == 0)
                    yield return new object[] { i, 0 };

                if (0 < i && i <= 5)
                    yield return new object[] { i, 5 };
                if (6 <= i && i <= 10)
                    yield return new object[] { i, 8 };
                if (11 <= i && i <= 15)
                    yield return new object[] { i, 12 };
                if (16 <= i && i <= 20)
                    yield return new object[] { i, 17};
                if (21 <= i && i <= 25)
                    yield return new object[] { i, 23 };
                if (26 <= i && i <= 30)
                    yield return new object[] { i, 30 };
                if (31 <= i && i <= 35)
                    yield return new object[] { i, 38 };
                if (36 <= i && i <= 40)
                    yield return new object[] { i, 47 };
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
