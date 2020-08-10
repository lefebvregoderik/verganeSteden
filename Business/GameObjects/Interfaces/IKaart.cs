using VerganeSteden.Enum;

namespace VerganeSteden.GameObjects
{
    public interface IKaart
    {
        Kleur Kleur { get; set; }
        int Waarde { get; set; }
        bool IsVermenigvuldiger { get; set; }
    }
}