using VerganeSteden.Enum;

namespace VerganeSteden.GameObjects
{
    public class Kaart: IKaart
    {
        public Kleur Kleur {get; set;}
        public int Waarde { get; set; } = 0;
        public bool IsVermenigvuldiger { get; set; } = false;

        public Kaart() {}
    }
}
