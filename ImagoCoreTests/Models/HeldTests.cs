using ImagoCore.Enums;
using ImagoCore.Models;
using ImagoCore.Models.Events;
using ImagoCore.Models.Strategies;
using Moq;
using System;
using Xunit;

namespace ImagoCore.Test.Models
{
    public class HeldTests
    {
        [Fact]
        public void ConstructAttribute_AttributeIsNotNullOrEmpty()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();
                       
            var held = new Spieler(mock.Object);

            Assert.NotNull(held.Attribute);
            Assert.NotEmpty(held.Attribute);
        }

        [Fact]
        public void ConstructHeld_FertigkeitenIsNotNullOrEmpty()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler(mock.Object);

            Assert.NotNull(held.FertigkeitsKategorien);
            Assert.NotEmpty(held.FertigkeitsKategorien);
        }

        [Fact]
        public void ConstructHeld_KoerperIsNotNullOrEmpty()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler(mock.Object);

            Assert.NotNull(held.Koerper);
            Assert.NotEmpty(held.Koerper);
        }

        [Fact]
        public void HandleFaktischerWertAttributChanged_SenderIsAttributeCollection_ThrowsNoException()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler(mock.Object);
            AttributeCollection attribute = new AttributeCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoAttribut.Staerke);
            

            Action testCode = () => held.HandleFaktischerWertAttributChanged(attribute, new FaktischerWertChangedEventArgs(id));

            var ex = Record.Exception(testCode);

            Assert.Null(ex);
        }

        [Fact]
        public void HandleFaktischerWertAttributChanged_SenderIsAttributeCollectionObjectIsNoAttribut_ThrowsException()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler(mock.Object);
            AttributeCollection attribute = new AttributeCollection();
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoFertigkeit.Blasrohre);


            Action testCode = () => held.HandleFaktischerWertAttributChanged(attribute, new FaktischerWertChangedEventArgs(id));

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);
        }

        [Fact]
        public void HandleFaktischerWertAttributChanged_SenderIsNoAttribut_ThrowsInvalidCastException()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler(mock.Object);
            object attribut = new object();

            Action testCode = () => held.HandleFaktischerWertAttributChanged(attribut, new FaktischerWertChangedEventArgs());                       

            Assert.ThrowsAny<InvalidCastException>(testCode);
        }

        
    }
}
