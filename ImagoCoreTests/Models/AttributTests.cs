using ImagoCore.Enums;
using ImagoCore.Models;
using ImagoCore.Models.Events;
using Xunit;

namespace ImagoCore.Tests.Models
{
    public class AttributTests
    {      

        [Fact]
        public void ChangeNw_RaisesEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoAttribut.Staerke);
            var attribut = new Attribut(id);
            var args = new FaktischerWertChangedEventArgs(id);

            var evt = Assert.RaisesAny<FaktischerWertChangedEventArgs>(
                h => attribut.FaktischerWertChanged += h,
                h => attribut.FaktischerWertChanged -= h,
                () => attribut.NatuerlicherWert = 5);

            Assert.NotNull(evt);
            Assert.Equal(attribut, evt.Sender);
            Assert.Equal(args, evt.Arguments);                    
        }

        [Fact]
        public void ChangeKorrosion_RaisesEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoAttribut.Staerke);
            var attribut = new Attribut(id);
            var args = new FaktischerWertChangedEventArgs(id);

            var evt = Assert.RaisesAny<FaktischerWertChangedEventArgs>(
                h => attribut.FaktischerWertChanged += h,
                h => attribut.FaktischerWertChanged -= h,
                () => attribut.Korrosion = 5);

            Assert.NotNull(evt);
            Assert.Equal(attribut, evt.Sender);
            Assert.Equal(args, evt.Arguments);
        }

        [Fact]
        public void ChangeModifikation_RaisesEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoAttribut.Staerke);
            var attribut = new Attribut(id);
            var args = new FaktischerWertChangedEventArgs(id);

            var evt = Assert.RaisesAny<FaktischerWertChangedEventArgs>(
                h => attribut.FaktischerWertChanged += h,
                h => attribut.FaktischerWertChanged -= h,
                () => attribut.Modifikation = 5);

            Assert.NotNull(evt);
            Assert.Equal(attribut, evt.Sender);
            Assert.Equal(args, evt.Arguments);
        }

        [Fact]
        public void ChangeErfahrung_RaisesNoEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoAttribut.Staerke);
            var attribut = new Attribut(id);
            var args = new FaktischerWertChangedEventArgs(id);

            attribut.Erfahrung = 5;            

            //todo
            //no assert available
        }

        
    }
}
