using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ImagoCore.TestData;
using System.Linq;
using Xunit.Abstractions;

namespace ImagoCore.Tests.TestData
{
    public class TestDataTests
    {
        private readonly ITestOutputHelper _output;

        public TestDataTests( ITestOutputHelper output )
        {
            _output = output;
        }       

        [Fact]
        public void GetTestSpieler_AttributValuesDiffer()
        {
            var spieler = ImagoCore.TestData.TestData.GetTestSpieler();
            //Annahme: Sobald drei Attribute denselben Steigerungswert haben, liegen keine echten Zufallszahlen vor
            var triplicates = spieler.Attribute.GroupBy( attr => attr.SteigerungsWert ).Any( group => group.Count() > 2 );

            _output.WriteLine( "Attributwerte SteigerungsWert TestSpieler {0}: {1}, {2}, {3}, {4}, {5}, {6}, {7}.", spieler.Name, spieler.Attribute.Staerke.SteigerungsWert,
                spieler.Attribute.Geschicklichkeit.SteigerungsWert, spieler.Attribute.Konstitution.SteigerungsWert, spieler.Attribute.Intelligenz.SteigerungsWert,
                spieler.Attribute.Willenskraft.SteigerungsWert, spieler.Attribute.Charisma.SteigerungsWert, spieler.Attribute.Wahrnehmung.SteigerungsWert );

            Assert.False( triplicates );
        }
    }
}
