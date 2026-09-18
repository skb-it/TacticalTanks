namespace TacticalTanks.Api.Models
{
    public readonly record struct Position(int X, int Y)
    {
        public int ManhattanDistance(Position target) =>
            Math.Abs(X - target.X) + Math.Abs(Y - target.Y);

        public double EuclideanDistance(Position target)
        {
            int distanceX = X - target.X;
            int distanceY = Y - target.Y;

            return Math.Sqrt(distanceX*distanceX + distanceY * distanceY);
        }
    }




}
