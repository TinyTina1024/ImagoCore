using System;
using Xunit;
using System.Collections.Generic;
using System.Collections;
using ImagoCore.Models.Strategies;
using ImagoCore.Models;

namespace ImagoCore.Tests.Models.Strategies
{
    public class FertigkeitVeraendernServiceTest
    {
        private readonly FertigkeitVeraendernService _service;

        public FertigkeitVeraendernServiceTest()
        {
            _service = new FertigkeitVeraendernService();
        }

        [Theory]
        [ClassData(typeof(FertigkeitSteigernGenugEpTestData))]
        public void SteigereFertigkeit_FertigkeitHasGenugEp_SteigerungWertInc(int aktuellerSteigerungsWert, int verfuegbareEp, int erwarteterSteigerungsWert)
        {
            SteigerbareFertigkeitBase fertigkeit = new Fertigkeit() { SteigerungsWert = aktuellerSteigerungsWert, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = (fertigkeit).SteigerungsWert;

            Assert.Equal(erwarteterSteigerungsWert, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitSteigernNichtGenugEpTestData))]
        public void SteigereFertigkeit_FertigkeitHasNotGenugEp_SteigerungWertNoInc(int aktuellerSteigerungsWert, int verfuegbareEp, int erwarteterSteigerungsWert)
        {
            SteigerbareFertigkeitBase fertigkeit = new Fertigkeit() { SteigerungsWert = aktuellerSteigerungsWert, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = (fertigkeit).SteigerungsWert;

            Assert.Equal(erwarteterSteigerungsWert, result);
        }

        [Theory]
        [ClassData(typeof(AttributSteigernGenugEpTestData))]
        public void SteigereFertigkeit_AttributHasGenugEp_SteigerungWertInc(int aktuellerNw, int verfuegbareEp, int erwarteterNw)
        {
            SteigerbareFertigkeitBase fertigkeit = new Attribut() { SteigerungsWert = aktuellerNw, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = fertigkeit.SteigerungsWert;

            Assert.Equal(erwarteterNw, result);
        }

        [Theory]
        [ClassData(typeof(AttributSteigernNichtGenugEpTestData))]
        public void SteigereFertigkeit_AttributHasNotGenugEp_SteigerungWertNoInc(int aktuellerNw, int verfuegbareEp, int erwarteterNw)
        {
            SteigerbareFertigkeitBase fertigkeit = new Attribut() { SteigerungsWert = aktuellerNw, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = fertigkeit.SteigerungsWert;

            Assert.Equal(erwarteterNw, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitsKategorieSteigernGenugEpTestData))]
        public void SteigereFertigkeit_FertigkeitsKategorieHasGenugEp_SteigerungWertInc(int aktuellerSteigerungsWert, int verfuegbareEp, int erwarteterSteigerungsWert)
        {
            SteigerbareFertigkeitBase fertigkeit = new FertigkeitsKategorie() { SteigerungsWert = aktuellerSteigerungsWert, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = fertigkeit.SteigerungsWert;

            Assert.Equal(erwarteterSteigerungsWert, result);
        }

        [Theory]
        [ClassData(typeof(FertigkeitsKategorieSteigernNichtGenugEpTestData))]
        public void SteigereFertigkeit_FertigkeitsKategorieHasNotGenugEp_SteigerungWertNoInc(int aktuellerSteigerungsWert, int verfuegbareEp, int erwarteterSteigerungsWert)
        {
            SteigerbareFertigkeitBase fertigkeit = new FertigkeitsKategorie() { SteigerungsWert = aktuellerSteigerungsWert, Erfahrung = verfuegbareEp };
            _service.SteigereFertigkeit(ref fertigkeit);
            var result = fertigkeit.SteigerungsWert;

            Assert.Equal(erwarteterSteigerungsWert, result);
        }
    }

    public class FertigkeitSteigernGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 14)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(2, 10), i + 1 };
                }
                if (15 <= i && i <= 29)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(3, 11), i + 1 };
                }
                if (30 <= i && i <= 44)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(5, 13), i + 1 };
                }
                if (45 <= i && i <= 59)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(8, 16), i + 1 };
                }
                if (60 <= i && i <= 74)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(12, 21), i + 1 };
                }
                if (75 <= i && i <= 89)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(17, 30), i + 1 };
                }
                if (90 <= i)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(23, 38), i + 1 };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }

    public class FertigkeitSteigernNichtGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 14)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 2), i  };
                }
                if (15 <= i && i <= 29)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 3), i  };
                }
                if (30 <= i && i <= 44)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 5), i  };
                }
                if (45 <= i && i <= 59)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 8), i  };
                }
                if (60 <= i && i <= 74)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 12), i };
                }
                if (75 <= i && i <= 89)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 17), i  };
                }
                if (90 <= i)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 23), i  };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }


    public class AttributSteigernGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 99; i++)
            {
                if (0 <= i && i <= 39)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(2, 10), i + 1 };
                }
                if (40 <= i && i <= 49)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(3, 11), i + 1 };
                }
                if (50 <= i && i <= 59)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(5, 13), i + 1 };
                }
                if (60 <= i && i <= 69)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(8, 16), i + 1 };
                }
                if (70 <= i && i <= 79)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(12, 21), i + 1 };
                }
                if (80 <= i && i <= 89)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(17, 30), i + 1 };
                }
                if (90 <= i)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(23, 38), i + 1 };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class AttributSteigernNichtGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 39)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 2), i  };
                }
                if (40 <= i && i <= 49)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 3), i };
                }
                if (50 <= i && i <= 59)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 5), i  };
                }
                if (60 <= i && i <= 69)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 8), i  };
                }
                if (70 <= i && i <= 79)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 12), i  };
                }
                if (80 <= i && i <= 89)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 17), i };
                }
                if (90 <= i)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 23), i  };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class FertigkeitsKategorieSteigernGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 4)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(5, 10), i + 1 };
                }
                if (5 <= i && i <= 9)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(8, 12), i + 1 };
                }
                if (10 <= i && i <= 14)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(12, 15), i + 1 };
                }
                if (15 <= i && i <= 19)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(17, 25), i + 1 };
                }
                if (20 <= i && i <= 24)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(23, 30), i + 1 };
                }
                if (25 <= i && i <= 29)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(30, 40), i + 1 };
                }
                if (30 <= i && i <= 34)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(38, 50), i + 1 };
                }
                if (35 <= i && i <= 39)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(47, 60), i + 1 };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class FertigkeitsKategorieSteigernNichtGenugEpTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (0 <= i && i <= 4)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 5), i  };
                }
                if (5 <= i && i <= 9)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 8), i };
                }
                if (10 <= i && i <= 14)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 12), i  };
                }
                if (15 <= i && i <= 19)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 17), i };
                }
                if (20 <= i && i <= 24)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 23), i  };
                }
                if (25 <= i && i <= 29)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 30), i  };
                }
                if (30 <= i && i <= 34)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 38), i  };
                }
                if (35 <= i && i <= 39)
                {
                    var random = new Random();
                    yield return new object[] { i, random.Next(0, 47), i  };
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

     
}
