using ImagoCore.Enums;
using ImagoCore.Models;
using ImagoCore.Models.Events;
using System;
using System.Collections.Generic;
using Xunit;

namespace ImagoCore.Tests.Models
{
    public class FertigkeitsKategorieTests
    {
        private readonly List<ImagoAttribut> attribute = new List<ImagoAttribut>(ImagoAttribut.GetAll<ImagoAttribut>());
        
        /// <summary>
        /// Erzeugt fuer jedes Attribut einen Zufallswert zwischen 0 - 100
        /// </summary>
        /// <returns></returns>
        private Dictionary<ImagoAttribut, int> GetTestDaten()
        {
            var result = new Dictionary<ImagoAttribut, int>();
            foreach (ImagoAttribut attr in attribute)
            {
                var random = new Random().Next(0, 101);
                result.Add(attr, random);
            }
            return result;
        }

        [Fact]
        public void berechneNatuerlicherWert_KategorieHasNoAttribute_NoException()
        {
            var fk = new FertigkeitsKategorie();
            Action testCode = () => fk.BerechneNatuerlicherWert(GetTestDaten());

            var ex = Record.Exception(testCode);

            Assert.Null(ex);
        }

        [Fact]
        public void berechneNatuerlicherWert_KategorieHasAttribute_NatuerlicherWertVeraendert()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoFertigkeitsKategorie.Nahkampf);
            var fk = new FertigkeitsKategorie(id, new ImagoAttribut[] { ImagoAttribut.Staerke, ImagoAttribut.Staerke, ImagoAttribut.Staerke , ImagoAttribut.Staerke }, new Fertigkeit[] { } );
            fk.NatuerlicherWert = 0;

            var testDaten = new Dictionary<ImagoAttribut, int>();
            testDaten.Add(ImagoAttribut.Staerke, 15);

            fk.BerechneNatuerlicherWert(testDaten);

            Assert.Equal(10, fk.NatuerlicherWert);
        }

        [Fact]
        public void ChangeNw_RaisesEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoFertigkeitsKategorie.Nahkampf);
            var kategorie = new FertigkeitsKategorie(id, new ImagoAttribut[] { ImagoAttribut.Staerke, ImagoAttribut.Staerke, ImagoAttribut.Staerke, ImagoAttribut.Staerke }, new Fertigkeit[] { } );
            var args = new FaktischerWertChangedEventArgs(id);

            var evt = Assert.RaisesAny<FaktischerWertChangedEventArgs>(
                h => kategorie.FaktischerWertChanged += h,
                h => kategorie.FaktischerWertChanged -= h,
                () => kategorie.NatuerlicherWert = 5);

            Assert.NotNull(evt);
            Assert.Equal(kategorie, evt.Sender);
            Assert.Equal(args, evt.Arguments);
        }

        [Fact]
        public void ChangeModifikation_RaisesEvent()
        {
            var id = ImagoEntitaetFactory.GetNewEntitaet(ImagoFertigkeitsKategorie.Nahkampf);
            var kategorie = new FertigkeitsKategorie(id, new ImagoAttribut[] { ImagoAttribut.Staerke, ImagoAttribut.Staerke, ImagoAttribut.Staerke, ImagoAttribut.Staerke }, new Fertigkeit[] { } );
            var args = new FaktischerWertChangedEventArgs(id);

            var evt = Assert.RaisesAny<FaktischerWertChangedEventArgs>(
                h => kategorie.FaktischerWertChanged += h,
                h => kategorie.FaktischerWertChanged -= h,
                () => kategorie.Modifikation = 5);

            Assert.NotNull(evt);
            Assert.Equal(kategorie, evt.Sender);
            Assert.Equal(args, evt.Arguments);
        }

    }
}
