using System.Collections.Generic;
using VerganeSteden.Enum;

namespace VerganeSteden.GameObjects
{
    public interface IOntdekkingsStapel
    {
        List<IKaart> Stapel { get; }
        Kleur Kleur { get; set; }
        int Waarde { get; }

        void SpeelKaart(IKaart kaart);
        bool MagKaartSpelen(IKaart kaart);
    }
}