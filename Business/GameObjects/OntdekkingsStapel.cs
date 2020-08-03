using Business.Enum;
using Business.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VerganeSteden.GameObjects
{
    public class OntdekkingsStapel : IOntdekkingsStapel
    {
        public static readonly int startwaarde = -20;
        public static readonly int bonus = 20;
        public List<IKaart> Stapel { get; } = new List<IKaart>();
        public Kleur Kleur { get; set; }
        public int Waarde
        {
            get {
                if (Stapel.Count == 0) return 0;

                int waardeStapel = startwaarde + Stapel.Select(k => k.Waarde).Sum();
                if (Stapel.Count >= 6) waardeStapel += bonus;
                return waardeStapel;
            }
        }

        public bool MagKaartSpelen(IKaart kaart)
        {
            bool isWaardeOk = (Stapel.Count() == 0)
                                ? true
                                : Stapel.Last().Waarde <= kaart.Waarde;                                
            bool isKleurOk = Kleur == kaart.Kleur;
            return isWaardeOk && isKleurOk;
        }

    }
}
