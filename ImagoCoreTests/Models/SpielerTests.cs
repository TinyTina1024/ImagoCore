using ImagoCore.Enums;
using ImagoCore.Models;
using ImagoCore.Models.Events;
using ImagoCore.Models.Strategies;
using Moq;
using System.Linq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ImagoCore.Tests.Models
{
    public class SpielerTests
    {
        private readonly ITestOutputHelper output;

        public SpielerTests( ITestOutputHelper output )
        {
            this.output = output;
        }

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
            Assert.NotNull( held.FertigkeitsKategorien.Bewegung );
            Assert.NotNull( held.FertigkeitsKategorien.Fernkampf );
            Assert.NotNull( held.FertigkeitsKategorien.Handwerk );
            Assert.NotNull( held.FertigkeitsKategorien.Heimlichkeit );
            Assert.NotNull( held.FertigkeitsKategorien.Nahkampf );
            Assert.NotNull( held.FertigkeitsKategorien.Soziales );
            Assert.NotNull( held.FertigkeitsKategorien.Webkunst );
            Assert.NotNull( held.FertigkeitsKategorien.Wissenschaft );
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
        public void ConstructSpieler_FertigkeitenAreValid()
        {
            var mock = new Mock<IFertigkeitVeraendernService>();

            var held = new Spieler( mock.Object );
            var fertigkeiten = held.FertigkeitsKategorien;

            //es gibt 8 Kategorien
            Assert.Equal( 8, fertigkeiten.Count );
            foreach( var item in fertigkeiten )
            {
                output.WriteLine(GetKategorieString(item));
            }

            string GetKategorieString( FertigkeitsKategorie kategorie )
            {
                var fert = string.Join( ", ", kategorie.Fertigkeiten );
                return string.Format( "Kategorie: {0} Attributreferenzen: {1}, Fertigkeiten: {2}", kategorie.Identifier.Identifier.DisplayName, kategorie.AttributReferenzen.ToString(), fert );
            }
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

        [Fact]
        public void SteigereFertigkeit_AttributMitGenugEp_AttributWurdeGesteigert()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            SteigerbareFertigkeitBase attribut = spieler.Attribute.Staerke;
            attribut.SteigerungsWert = 0;
            attribut.Erfahrung = 2;
            spieler.SteigereFertigkeit( ref attribut );

            Assert.True( attribut.SteigerungsWert == 1 );
            Assert.True( attribut.Erfahrung == 0 );
        }

        [Fact]
        public void ReduziereFertigkeit_Attribut_AttributWurdeReduziert()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            SteigerbareFertigkeitBase attribut = spieler.Attribute.Staerke;
            attribut.SteigerungsWert = 5;            
            spieler.ReduziereFertigkeit( ref attribut );

            Assert.True( attribut.SteigerungsWert == 4 );
            Assert.True( attribut.Erfahrung > 0 );
        }

        [Fact]
        public void SteigereFertigkeit_FertigkeitMitGenugEp_FertigkeitUndKategorieWurdenGesteigert()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            FertigkeitsKategorie kategorie = spieler.FertigkeitsKategorien.Nahkampf;
            kategorie.Erfahrung = 0;
            SteigerbareFertigkeitBase fertigkeit = kategorie.Fertigkeiten.FirstOrDefault();
            fertigkeit.SteigerungsWert = 0;
            fertigkeit.Erfahrung = 2;
            spieler.SteigereFertigkeit( ref fertigkeit);

            Assert.True( fertigkeit.SteigerungsWert == 1 );
            Assert.True( fertigkeit.Erfahrung == 0 );
            Assert.True( kategorie.Erfahrung == 1 );
        }

        [Fact]
        public void ReduziereFertigkeit_Fertigkeit_FertigkeitWurdeReduziertKategorieWenigerEp()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            FertigkeitsKategorie kategorie = spieler.FertigkeitsKategorien.Nahkampf;
            kategorie.Erfahrung = 1;
            SteigerbareFertigkeitBase fertigkeit = kategorie.Fertigkeiten.FirstOrDefault();
            fertigkeit.SteigerungsWert = 1;
            fertigkeit.Erfahrung = 0;
            spieler.ReduziereFertigkeit( ref fertigkeit );

            Assert.True( fertigkeit.SteigerungsWert == 0 );
            Assert.True( fertigkeit.Erfahrung == 2 );
            Assert.True( kategorie.Erfahrung == 0 );
        }

        [Fact]
        public void SteigereFertigkeit_FertigkeitsKategorie_KategorieWurdeGesteigert()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            SteigerbareFertigkeitBase kategorie = spieler.FertigkeitsKategorien.Nahkampf;
            kategorie.Erfahrung = 5;
            kategorie.SteigerungsWert = 0;
            spieler.SteigereFertigkeit( ref kategorie );

            Assert.True( kategorie.SteigerungsWert == 1 );
            Assert.True( kategorie.Erfahrung == 0 );
        }

        [Fact]
        public void ReduziereFertigkeit_FertigkeitsKategorie_NichtsPassiert()
        {
            var spieler = new Spieler( new FertigkeitVeraendernService() );

            SteigerbareFertigkeitBase kategorie = spieler.FertigkeitsKategorien.Nahkampf;
            kategorie.Erfahrung = 0;
            kategorie.SteigerungsWert = 1;
            spieler.ReduziereFertigkeit( ref kategorie );

            Assert.True( kategorie.SteigerungsWert == 1 );
            Assert.True( kategorie.Erfahrung == 0 );
        }

    }
}
