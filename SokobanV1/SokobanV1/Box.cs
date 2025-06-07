using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SokobanV1
{
    public class Box
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Box(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsOnTarget(List<TargetSpot> targetSpots)
        {
            foreach (TargetSpot spot in targetSpots)
            {
                if (spot.X == X && spot.Y == Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAt(int x, int y)
        {
            if (X == x && Y == y)
                return true;
            else
                return false;
        }

        public bool TryMoveTo(int newX, int newY, List<Obstacle> obstacles, int gridSize)
        {
            if (newX < 0 || newX >= gridSize || newY < 0 || newY >= gridSize)
                return false;

            if (obstacles.Any(o => o.X == newX && o.Y == newY))
                return false;

            X = newX;
            Y = newY;
            return true;
        }

    }

}
