using TacticalTanks.Api.Interfaces;

namespace TacticalTanks.Api.Models

{
    public class Tank : ITank
    {
        public Position Positioning {  get; private set; }
        public double MaxHp { get; }
        public double CurrentHp { get; private set; }
        public int Visibility { get; }
        public int MoveRange { get; }
        public int VisionRange { get; }
        public double Damage { get; }
        public double Armour { get; } 
        public int GunRange { get; }

        private Tank(String name, double maxHp, int visibility, int moveRange, int visionRange, double damage, double armour, int gunRange, Position positioning)
        {
            MaxHp = maxHp;
            CurrentHp = maxHp;
            Visibility = visibility;
            MoveRange = moveRange;
            VisionRange = visionRange;
            Damage = damage;
            Armour = armour;
            Positioning = positioning;
            GunRange = gunRange;
        }

        public static Tank LightTank(Position positioning) => new Tank("Czołg lekki", 6000.0, 100, 4, 200, 600.0, 600.0, 50, positioning);
        public static Tank MediumTank(Position positioning) => new Tank("Czołg średni", 8000.0, 200, 4, 100, 800.0, 800.0, 100, positioning);
        public static Tank HeavyTank(Position positioning) => new Tank("Czołg ciężki", 10000.0, 300, 4, 50, 1000.0, 1000.0, 200, positioning);
        public static Tank Artillery(Position positioning) => new Tank("Artyleria", 1000.0, 200, 2, 10, 2000.0, 200.0, 1000, positioning);



        public void MoveTo(Position position)
        {
            Positioning = position;
        }
        public void TakeDamage(double damage)
        {
            CurrentHp -= damage;
        }
        //void Repair(double amount);

        //void Cure(double cureSoldier)

    }
}
        
        


