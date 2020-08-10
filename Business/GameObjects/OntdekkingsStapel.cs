using VerganeSteden.Enum;
using VerganeSteden.Exceptions;
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

                int vermenigvuldigingsfactor = Stapel.Count(k => k.IsVermenigvuldiger) + 1;
                int waardeStapel = vermenigvuldigingsfactor 
                                        * (startwaarde + Stapel.Select(k => k.Waarde).Sum());
                if (Stapel.Count >= 8) waardeStapel += bonus;
                return waardeStapel;
            }
        }

        public IOntdekkingsStapel SpeelKaart(IKaart kaart)
        {
            if (!MagKaartSpelen(kaart))
            {
                throw new OngeldigeZetException("ongeldige zet");
            }

            Stapel.Add(kaart);

            return this;
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
