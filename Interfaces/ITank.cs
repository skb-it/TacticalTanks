using TacticalTanks.Api.Models;

namespace TacticalTanks.Api.Interfaces
{
    public interface ITank
    {
        Position Positioning { get; }
        double MaxHp { get; }
        double CurrentHp {  get; }
        int Visibility { get; }
        int MoveRange { get; }
        int VisionRange { get; }
        double Damage { get; }
        double Armour { get; }
        int GunRange { get; }

        void MoveTo(Position positioning);
        void TakeDamage(double damage);
        //void Repair(double amount);
        //void ApplyStatBonus(int bonusVision, double bonusArmour);
    }
}
