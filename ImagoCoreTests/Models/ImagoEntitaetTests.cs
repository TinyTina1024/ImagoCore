using ImagoCore.Enums;
using ImagoCore.Models;
using Xunit;

namespace ImagoApp.Test.Models
{
    public class ImagoEntitaetTests
    {
        
        public ImagoEntitaetTests()
        {
                
        }

        [Fact]
        public void ImagoEntitaetFactory_GetRandomEntitaet()
        {
            Assert.NotNull(ImagoEntitaetFactory.GetRandomEntitaet());
        }

        [Fact]
        public void ImagoEntitaetFactory_GetNewEntitaet_ValidInput_GetEntitaet()
        {
            var entitaet = ImagoEntitaetFactory.GetNewEntitaet(ImagoFertigkeit.Alchemie);

            Assert.NotNull(entitaet);
            Assert.NotNull(entitaet.Bereich);
            Assert.NotNull(entitaet.Identifier);
        }
    }
}
