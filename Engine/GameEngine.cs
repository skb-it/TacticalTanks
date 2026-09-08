using TacticalTanks.Api.Models;
using TacticalTanks.Api.Interfaces;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;

namespace TacticalTanks.Api.Engine
{
    public class GameEngine : IGameEngine
    {

        
        private bool IsTileBlocked(Position tile)
        {
            // TO DO
            return true;
        }
        private bool HasClearLineOfFire(Position from, Position to)
        {
            int x0 = from.X;
            int y0 = from.Y;
            int x1 = to.X;
            int y1 = to.Y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                Position currentStep = new Position(x0, y0);
                if (currentStep != from && currentStep != to)
                {
                    if (IsTileBlocked(currentStep))
                    {
                        return false;
                    }
                }

                if (x0 == x1 && y0 == y1)
                {
                    break;
                }

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }

            return true;
        }
        private bool CanShoot(ITank attacker, ITank target, int gunRange)
        {
            double distance = attacker.Positioning.EuclideanDistance(target.Positioning);
            if (distance > gunRange)
            {
                return false;
            }
            else
            {
                bool isLineOfFireIsClear = HasClearLineOfFire(attacker.Positioning, target.Positioning);
                if (isLineOfFireIsClear)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Shoot(ITank attacker, ITank target )
        {
            if(CanShoot(attacker, target, attacker.GunRange) == true)
            {
                //TO DO
            }
            else
            {
                //TO DO
            }
        }

    }
}
