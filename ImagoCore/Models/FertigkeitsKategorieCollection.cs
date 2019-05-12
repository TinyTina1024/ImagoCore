using ImagoCore.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static ImagoCore.Models.ImagoEntitaetFactory;

namespace ImagoCore.Models
{
    public class FertigkeitsKategorieCollection : ICollection<FertigkeitsKategorie>
    {     
        public FertigkeitsKategorie Bewegung { get; set; }
        public FertigkeitsKategorie Nahkampf { get; set; }
        public FertigkeitsKategorie Heimlichkeit { get; set; }
        public FertigkeitsKategorie Fernkampf { get; set; }
        public FertigkeitsKategorie Webkunst { get; set; }
        public FertigkeitsKategorie Wissenschaft { get; set; }
        public FertigkeitsKategorie Handwerk { get; set; }
        public FertigkeitsKategorie Soziales { get; set; }

        public int Count => 8;

        public bool IsReadOnly => true;

        public FertigkeitsKategorieCollection()
        {
            Bewegung = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Bewegung), new ImagoAttribut[4] { ImagoAttribut.Staerke, ImagoAttribut.Geschicklichkeit, ImagoAttribut.Konstitution, ImagoAttribut.Konstitution })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Ausweichen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Klettern)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Koerperbeherrschung)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Laufen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Reiten)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Schwimmen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Springen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Tanzen))
                }

            };

            Nahkampf = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Nahkampf), new ImagoAttribut[4] { ImagoAttribut.Staerke, ImagoAttribut.Geschicklichkeit, ImagoAttribut.Konstitution, ImagoAttribut.Wahrnehmung })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Dolche)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Hiebwaffen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Schilde)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Schwerter)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.StaebeSpeere)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Waffenlos)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Zweihaender)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Springen)),
                }
            };

            Fernkampf = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Fernkampf), new ImagoAttribut[4] { ImagoAttribut.Staerke, ImagoAttribut.Geschicklichkeit, ImagoAttribut.Geschicklichkeit, ImagoAttribut.Wahrnehmung })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Armbrueste)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Blasrohre)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Boegen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Schleuder)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Wurfgeschosse)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Wurfwaffen))
                }
            };

            Heimlichkeit = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Heimlichkeit), new ImagoAttribut[4] { ImagoAttribut.Geschicklichkeit, ImagoAttribut.Intelligenz, ImagoAttribut.Willenskraft, ImagoAttribut.Wahrnehmung })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Schleichen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Sicherheit)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.SpurenLesen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Taschendiebstahl)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Verstecken)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Verbergen)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Verkleiden))
                }
            };

            Webkunst = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Webkunst), new ImagoAttribut[4] { ImagoAttribut.Willenskraft, ImagoAttribut.Willenskraft, ImagoAttribut.Charisma, ImagoAttribut.Charisma })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Bewusstsein)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Chaos)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Einfalt)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Ekstase)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Kontrolle)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Leere)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Materie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Struktur))
                }
            };

            Wissenschaft = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Wissenschaft), new ImagoAttribut[4] { ImagoAttribut.Intelligenz, ImagoAttribut.Intelligenz, ImagoAttribut.Intelligenz, ImagoAttribut.Wahrnehmung })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Anatomie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Literatur)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Mathematik)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Philosophie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Physik)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Soziologie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Sphaerologie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.WirtschaftRecht))
                }
            };

            Handwerk = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Handwerk), new ImagoAttribut[4] { ImagoAttribut.Geschicklichkeit, ImagoAttribut.Intelligenz, ImagoAttribut.Charisma, ImagoAttribut.Charisma })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Alchemie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Heiler)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Naturkunde)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Sprache)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Strategie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Wundscher))
                }
            };

            Soziales = new FertigkeitsKategorie(GetNewEntitaet(ImagoFertigkeitsKategorie.Soziales), new ImagoAttribut[4] { ImagoAttribut.Willenskraft, ImagoAttribut.Charisma, ImagoAttribut.Charisma, ImagoAttribut.Wahrnehmung })
            {
                Fertigkeiten = new List<Fertigkeit>()
                {
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Anfuehren)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Ausdruck)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Einschuechtern)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Empathie)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Gesellschafter)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.Manipulation)),
                    new Fertigkeit(GetNewEntitaet(ImagoFertigkeit.SozialeAdaption))
                }
            };
        }

        public FertigkeitsKategorie GetParent(Fertigkeit fertigkeit)
        {            
            foreach (var item in this)
            {
                if (item.Fertigkeiten.Contains(fertigkeit))
                    return item;
            }

            throw new Exception(fertigkeit.ToString() + " konnte nicht in den Kategorien gefunden werden.");
        }

        #region IEnumerable<T>
        public IEnumerator<FertigkeitsKategorie> GetEnumerator()
        {
            yield return Bewegung;
            yield return Nahkampf;
            yield return Heimlichkeit;
            yield return Fernkampf;
            yield return Webkunst;
            yield return Wissenschaft;
            yield return Handwerk;
            yield return Soziales;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add( FertigkeitsKategorie item )
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains( FertigkeitsKategorie item )
        {
            throw new NotImplementedException();
        }

        public void CopyTo( FertigkeitsKategorie[] array, int arrayIndex )
        {
            throw new NotImplementedException();
        }

        public bool Remove( FertigkeitsKategorie item )
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
