namespace TacticalTanks.Api.Models
{
    public class Obstacle
    {
        public Position Positioning { get; }
        public string Name { get; }
        public bool CanItBeShotThrough { get; }

        private Obstacle(Position positioning, string name, bool canItBeShotThrough)
        {
            Positioning = positioning;
            Name = name;
            CanItBeShotThrough = canItBeShotThrough;
        }

        public static Obstacle Lake(Position positioning) => new Obstacle(positioning, "Lake", true);
        public static Obstacle Mountain(Position positioning) => new Obstacle(positioning, "Mountain", false);
    }
}

    

