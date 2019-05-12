using System.Collections.Generic;
using Xunit;
using ImagoCore.Models;
using ImagoCore.Enums;
using System.Collections;

namespace ImagoApp.Test.Models
{
    public class KoerperTests
    {
        [Fact]
        public void ConstructKoerper_KoerperHasKopf()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.Kopf);

            Assert.NotNull(koerper.Kopf);
            Assert.Equal(id, koerper.Kopf.Identifier);
        }
        [Fact]
        public void ConstructKoerper_KoerperHasTorso()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.Torso);

            Assert.NotNull(koerper.Torso);
            Assert.Equal(id, koerper.Torso.Identifier);
        }
        [Fact]
        public void ConstructKoerper_KoerperHasArmRechts()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.ArmRechts);

            Assert.NotNull(koerper.ArmRechts);
            Assert.Equal(id, koerper.ArmRechts.Identifier);
        }
        [Fact]
        public void ConstructKoerper_KoerperHasArmLinks()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.ArmLinks);

            Assert.NotNull(koerper.ArmLinks);
            Assert.Equal(id, koerper.ArmLinks.Identifier);
        }
        [Fact]
        public void ConstructKoerper_KoerperHasBeinRechts()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.BeinRechts);

            Assert.NotNull(koerper.BeinRechts);
            Assert.Equal(id, koerper.BeinRechts.Identifier);
        }
        [Fact]
        public void ConstructKoerper_KoerperHasBeinLinks()
        {
            var koerper = new KoerperTeileCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoKoerperTeil.BeinLinks);

            Assert.NotNull(koerper.BeinLinks);
            Assert.Equal(id, koerper.BeinLinks.Identifier);
        }

        [Theory]
        [ClassData(typeof(KopfTrefferpunkteBerechnenTestData))]
        public void KopfTrefferpunkteBerechnenStrategy(int konstitution, int expectedTp)
        {
            var koerper = new KoerperTeileCollection();
            koerper.Kopf.BerechneTrefferpunkte(konstitution);

            Assert.Equal(expectedTp, koerper.Kopf.MaxTrefferPunkte);            
        }

        [Theory]
        [ClassData(typeof(TorsoTrefferpunkteBerechnenTestData))]
        public void TorsoTrefferpunkteBerechnenStrategy(int konstitution, int expectedTp)
        {
            var koerper = new KoerperTeileCollection();
            koerper.Torso.BerechneTrefferpunkte(konstitution);

            Assert.Equal(expectedTp, koerper.Torso.MaxTrefferPunkte);
        }

        [Theory]
        [ClassData(typeof(ArmTrefferpunkteBerechnenTestData))]
        public void ArmTrefferpunkteBerechnenStrategy(int konstitution, int expectedTp)
        {
            var koerper = new KoerperTeileCollection();
            koerper.ArmRechts.BerechneTrefferpunkte(konstitution);
            koerper.ArmLinks.BerechneTrefferpunkte(konstitution);

            Assert.Equal(expectedTp, koerper.ArmRechts.MaxTrefferPunkte);
            Assert.Equal(expectedTp, koerper.ArmLinks.MaxTrefferPunkte);
        }

        [Theory]
        [ClassData(typeof(BeinTrefferpunkteBerechnenTestData))]
        public void BeinTrefferpunkteBerechnenStrategy(int konstitution, int expectedTp)
        {
            var koerper = new KoerperTeileCollection();
            koerper.BeinRechts.BerechneTrefferpunkte(konstitution);
            koerper.BeinLinks.BerechneTrefferpunkte(konstitution);

            Assert.Equal(expectedTp, koerper.BeinRechts.MaxTrefferPunkte);
            Assert.Equal(expectedTp, koerper.BeinLinks.MaxTrefferPunkte);
        }
    }

    public class KopfTrefferpunkteBerechnenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 115; i++)
            {
                if(i >= 0 && i <= 4)
                    yield return new object[] { i, 0 };
                if (5 <= i && i <= 14)
                    yield return new object[] { i, 1 };
                if (15 <= i && i <= 24)
                    yield return new object[] { i, 2 };
                if (25 <= i && i <= 34)
                    yield return new object[] { i, 3 };
                if (35 <= i && i <= 44)
                    yield return new object[] { i, 4 };
                if (45 <= i && i <= 54)
                    yield return new object[] { i, 5 };
                if (55 <= i && i <= 64)
                    yield return new object[] { i, 6 };
                if (65 <= i &&i  <= 74)
                    yield return new object[] { i, 7 };
                if (75 <= i && i <= 84)
                    yield return new object[] { i, 8 };
                if (85 <= i && i <= 94)
                    yield return new object[] { i, 9 };
                if (95 <= i && i <= 104)
                    yield return new object[] { i, 10 };
                if (105 <= i && i <= 114)
                    yield return new object[] { i, 11 };
                if (115 <= i && i <= 125)
                    yield return new object[] { i, 12 };

            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        
    }

    public class TorsoTrefferpunkteBerechnenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 115; i++)
            {
                if (i >= 0 && i <= 2 )
                    yield return new object[] { i, 0 };
                if (3 <= i && i <= 7)
                    yield return new object[] { i, 1 };
                if (8 <= i && i <= 12)
                    yield return new object[] { i, 2 };
                if (13 <= i && i <= 17)
                    yield return new object[] { i, 3 };
                if (18 <= i && i <= 22)
                    yield return new object[] { i, 4 };
                if (23 <= i && i <= 27)
                    yield return new object[] { i, 5 };
                if (28 <= i && i <= 32)
                    yield return new object[] { i, 6 };
                if (33 <= i && i <= 37)
                    yield return new object[] { i, 7 };
                if (38 <= i && i <= 42)
                    yield return new object[] { i, 8 };
                if (43 <= i && i <= 47)
                    yield return new object[] { i, 9 };
                if (48 <= i && i <= 52)
                    yield return new object[] { i, 10 };
                if (53 <= i && i <= 57)
                    yield return new object[] { i, 11 };
                if (58 <= i && i <= 62)
                    yield return new object[] { i, 12 };
                if (63 <= i && i <= 67)
                    yield return new object[] { i, 13 };
                if (68 <= i && i <= 72)
                    yield return new object[] { i, 14 };
                if (73 <= i && i <= 77)
                    yield return new object[] { i, 15 };
                if (78 <= i && i <= 82)
                    yield return new object[] { i, 16 };
                if (83 <= i && i <= 87)
                    yield return new object[] { i, 17 };
                if (88 <= i && i <= 92)
                    yield return new object[] { i, 18 };
                if (93 <= i && i <= 97)
                    yield return new object[] { i, 19 };
                if (98 <= i && i <= 102)
                    yield return new object[] { i, 20 };
                if (103 <= i && i <= 107)
                    yield return new object[] { i, 21 };
                if (108 <= i && i <= 112)
                    yield return new object[] { i, 22 };
                if (113 <= i && i <= 115)
                    yield return new object[] { i, 23 };

            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }

    public class ArmTrefferpunkteBerechnenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 115; i++)
            {
                if (i>= 0 && i <= 3)
                    yield return new object[] { i, 0 };
                if (4 <= i && i <= 10)
                    yield return new object[] { i, 1 };
                if (11 <= i && i <= 17)
                    yield return new object[] { i, 2 };
                if (18 <= i && i <= 24)
                    yield return new object[] { i, 3 };
                if (25 <= i && i <= 31)
                    yield return new object[] { i, 4 };
                if (32 <= i && i <= 38)
                    yield return new object[] { i, 5 };
                if (39 <= i && i <= 45)
                    yield return new object[] { i, 6 };
                if (46 <= i && i <= 52)
                    yield return new object[] { i, 7 };
                if (53 <= i && i <= 59)
                    yield return new object[] { i, 8 };
                if (60 <= i && i <= 66)
                    yield return new object[] { i, 9 };
                if (67 <= i && i <= 73)
                    yield return new object[] { i, 10 };
                if (74 <= i && i <= 80)
                    yield return new object[] { i, 11 };
                if (81 <= i && i <= 87)
                    yield return new object[] { i, 12 };
                if (88 <= i && i <= 94)
                    yield return new object[] { i, 13 };
                if (95 <= i && i <= 101)
                    yield return new object[] { i, 14 };
                if (102 <= i && i <= 108)
                    yield return new object[] { i, 15 };
                if (109 <= i && i <= 115)
                    yield return new object[] { i, 16 };              

            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
    public class BeinTrefferpunkteBerechnenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i <= 115; i++)
            {
                if (i >= 0 && i <= 2)
                    yield return new object[] { i, 0 };
                if (3 <= i && i <= 8)
                    yield return new object[] { i, 1 };
                if (9 <= i && i <= 14)
                    yield return new object[] { i, 2 };
                if (15 <= i && i <= 20)
                    yield return new object[] { i, 3 };
                if (21 <= i && i <= 26)
                    yield return new object[] { i, 4 };
                if (27 <= i && i <= 32)
                    yield return new object[] { i, 5 };
                if (33 <= i && i <= 38)
                    yield return new object[] { i, 6 };
                if (39 <= i && i <= 44)
                    yield return new object[] { i, 7 };
                if (45 <= i && i <= 50)
                    yield return new object[] { i, 8 };
                if (51 <= i && i <= 56)
                    yield return new object[] { i, 9 };
                if (57 <= i && i <= 62)
                    yield return new object[] { i, 10 };
                if (63 <= i && i <= 68)
                    yield return new object[] { i, 11 };
                if (69 <= i && i <= 74)
                    yield return new object[] { i, 12 };
                if (75 <= i && i <= 80)
                    yield return new object[] { i, 13 };
                if (81 <= i && i <= 86)
                    yield return new object[] { i, 14 };
                if (87 <= i && i <= 92)
                    yield return new object[] { i, 15 };
                if (93 <= i && i <= 98)
                    yield return new object[] { i, 16 };
                if (99 <= i && i <= 104)
                    yield return new object[] { i, 17 };
                if (105 <= i && i <= 110)
                    yield return new object[] { i, 18 };
                if (111 <= i && i <= 115)
                    yield return new object[] { i, 19 };

            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
