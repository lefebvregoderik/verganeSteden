using Business.Enum;

namespace Business.GameObjects
{
    public class Kaart: IKaart
    {
        public Kleur Kleur {get; set;}
        public int Waarde { get; set; }

        public Kaart() {}
    }
}
