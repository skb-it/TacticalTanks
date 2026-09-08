namespace TacticalTanks.Api.Models
{
    public class Map
    {
        public int X { get; }
        public int Y { get; }
        public int Size { get; }
        public Map(int x, int y)
        {
            X = x;
            Y = y;
            Size = X * Y;
        }
        
        
    }
}
