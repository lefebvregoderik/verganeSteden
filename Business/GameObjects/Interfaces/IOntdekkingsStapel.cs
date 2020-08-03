using System.Collections.Generic;
using Business.Enum;
using Business.GameObjects;

namespace VerganeSteden.GameObjects
{
    public interface IOntdekkingsStapel
    {
        List<IKaart> Stapel { get; }
        Kleur Kleur { get; set; }
        int Waarde { get; }
    }
}