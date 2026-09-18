using System.Collections;
using TacticalTanks.Api.Interfaces;
using TacticalTanks.Api.Models;

namespace TacticalTanks.Api.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IEnumerable _obstacles;
        private readonly IEnumerable _tanks;

        public GameEngine(IEnumerable<Obstacle> obstacles, IEnumerable<ITank> tanks)
        {
            _obstacles = obstacles;
            _tanks = tanks;
        }

        private bool IsThereObstacle(IEnumerable<Position> points, IEnumerable<Obstacle> obstacles)
        {
            var obstaclePositions = obstacles.Select(o => o.Positioning).ToHashSet();
            return points.Any(p => obstaclePositions.Contains(p));
        }

        private IEnumerable<Position> LineOfShoot(Position from, Position to)
        {
            var linePoints = new List<Position>();

            int x = from.X;
            int y = from.Y;
            int dx = Math.Abs(to.X - from.X);
            int dy = Math.Abs(to.Y - from.Y);
            int sx = from.X < to.X ? 1 : -1;
            int sy = from.Y < to.Y ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                linePoints.Add(new Position(x, y));

                if (x == to.X && y == to.Y)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }

            return linePoints;
        }

        private bool CanShoot(ITank attacker, ITank target, IEnumerable<Obstacle> obstacles)
        {
            double distance = attacker.Positioning.EuclideanDistance(target.Positioning);

            if (distance > attacker.GunRange)
            {
                return false;
            }

            var trajectory = LineOfShoot(attacker.Positioning, target.Positioning);

            return !IsThereObstacle(trajectory, obstacles);
        }

        public void Shoot(ITank attacker, ITank target)
        {
            if (CanShoot(attacker, target, _obstacles))
            {
                target.TakeDamage(attacker.Damage);
            }
            else
            {

            }
        }
    }


}