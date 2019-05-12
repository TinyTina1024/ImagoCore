using ImagoCore.Enums;
using ImagoCore.Models.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ImagoCore.Tests.Models.Strategies
{
    public class NatuerlicherWertBerechnenStrategyTests
    {
        public NatuerlicherWertBerechnenStrategyTests()
        {

        }

        [Fact]
        public void InitiativeBerechnen_InvalidInput_ThrowsException()
        {
            var strategy = new InitiativeNatuerlicherWertBerechnenStrategy();

            Action testCode = () => strategy.berechneNatuerlicherWert(GetInvalidTestData());

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);
            Assert.ThrowsAny<ArgumentException>(testCode);
        }

        [Theory]
        [ClassData(typeof(InitiativeBerechnenTestData))]
        public void InitiativeBerechnen_ValidTestData(Dictionary<ImagoAttribut, int> values, int expectedResult)
        {
            var strategy = new InitiativeNatuerlicherWertBerechnenStrategy();

            var result = strategy.berechneNatuerlicherWert(values);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(SchadensModBerechnenTestData))]
        public void SchadensModBerechnen_ValidTestData(Dictionary<ImagoAttribut, int> values, int expectedResult)
        {
            var strategy = new SchadensModifikationNatuerlicherWertBerechnenStrategy();

            var result = strategy.berechneNatuerlicherWert(values);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(SchadensModBerechnenTestData))]
        public void EgoRegBerechnen_ValidTestData(Dictionary<ImagoAttribut, int> values, int expectedResult)
        {
            var strategy = new SchadensModifikationNatuerlicherWertBerechnenStrategy();

            var result = strategy.berechneNatuerlicherWert(values);

            Assert.Equal(expectedResult, result);
        }

       

        private Dictionary<ImagoAttribut, int> GetInvalidTestData()
        {
            return new Dictionary<ImagoAttribut, int>();
        }
    }

    public class EgoRegBerechnenTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            Dictionary<ImagoAttribut, int> values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Willenskraft, 1);
            yield return new object[] { values, 0 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Willenskraft, 3);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Willenskraft, 11);
            yield return new object[] { values, 2 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Willenskraft, 3);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Willenskraft, 55);
            yield return new object[] { values, 11 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SchadensModBerechnenTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            Dictionary<ImagoAttribut, int> values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 1);           
            yield return new object[] { values, -2 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 20);
            yield return new object[] { values, -2 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 21);
            yield return new object[] { values, -1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 40);
            yield return new object[] { values, -1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 41);
            yield return new object[] { values, 0 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 50);
            yield return new object[] { values, 0 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 59);
            yield return new object[] { values, 0 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 60);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 65);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 70);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 79);
            yield return new object[] { values, 1 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 80);
            yield return new object[] { values, 2 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Staerke, 115);
            yield return new object[] { values, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InitiativeBerechnenTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            Dictionary<ImagoAttribut, int> values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 0);
            values.Add(ImagoAttribut.Willenskraft, 0);
            values.Add(ImagoAttribut.Wahrnehmung, 0);
            yield return new object[] { values, 0 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 40);
            values.Add(ImagoAttribut.Willenskraft, 40);
            values.Add(ImagoAttribut.Wahrnehmung, 40);            
            yield return new object[] { values, 40 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 50);
            values.Add(ImagoAttribut.Willenskraft, 50);
            values.Add(ImagoAttribut.Wahrnehmung, 50);            
            yield return new object[] { values, 50 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 80);
            values.Add(ImagoAttribut.Willenskraft, 80);
            values.Add(ImagoAttribut.Wahrnehmung, 80);            
            yield return new object[] { values, 80 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 45);
            values.Add(ImagoAttribut.Willenskraft, 40);
            values.Add(ImagoAttribut.Wahrnehmung, 50);            
            yield return new object[] { values, 45 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 55);
            values.Add(ImagoAttribut.Willenskraft, 53);
            values.Add(ImagoAttribut.Wahrnehmung, 57);            
            yield return new object[] { values, 55 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 51);
            values.Add(ImagoAttribut.Willenskraft, 56);
            values.Add(ImagoAttribut.Wahrnehmung, 49);           
            yield return new object[] { values, 52 };

            values = new Dictionary<ImagoAttribut, int>();
            values.Add(ImagoAttribut.Geschicklichkeit, 51);
            values.Add(ImagoAttribut.Willenskraft, 56);
            values.Add(ImagoAttribut.Wahrnehmung, 53);            
            yield return new object[] { values, 53 };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
