using Business.Enum;

namespace Business.GameObjects
{
    public interface IKaart
    {
        Kleur Kleur { get; set; }
        int Waarde { get; set; }
    }
}