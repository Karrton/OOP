using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft
{
    public class Unit
    {
        public Point position { get; set; }
        public float speed { get; private set; }
        public int maxCarryingCapacity { get; private set; }
        public int currentCarryingWeight { get; set; }

        public Mine CurrentMine;

        public bool IsInsideMine { get; set; }

        public static Image unitImage;
        private Random random;

        public Unit(Point initialPosition, float baseSpeed, int maxCarryingCapacity)
        {
            position = initialPosition;
            speed = baseSpeed;
            this.maxCarryingCapacity = maxCarryingCapacity;
            this.currentCarryingWeight = 0;
            CurrentMine = new Mine(new Point(), new int());
            random = new Random();

            if (unitImage == null)
            {
                unitImage = Image.FromFile("C:\\Users\\Dreamer\\Desktop\\Лабораторные и прочее\\ООП\\Warcraft\\miner.png");
            }
        }
        public int ToMine(int minAmount, int maxAmount)
        {
            // Генерация случайного количества золота в заданном диапазоне
            int goldMined = random.Next(minAmount, maxAmount + 1);
            return goldMined;
        }
        float GetLengthBetweenDot(Point point1, Point point2, float[,] heightMap)
        {
            float leg = heightMap[point1.X, point1.Y] - heightMap[point2.X, point2.Y];
            return (float)Math.Sqrt((Math.Pow((double)leg, 2.0) + 1.0));
        }
        public Point GetNearestVisibleMine(List<Mine> mines, float[,] heightMap)
        {
            int min = int.MaxValue;
            Point point1 = new Point();
            foreach (Mine mine in mines)
            {
                if ((int)GetLengthBetweenDot(position, mine.Location, heightMap) < min)
                {
                    min = (int)GetLengthBetweenDot(position, mine.Location, heightMap);
                    point1 = mine.Location;
                }
            }
            return point1;
        }
        public List<Point> FindPathTo(Point location, float[,] heightMap)
        {
            PathFinder pathFinder = new PathFinder();
            List<Point> path = pathFinder.FindPathTo(position, location, heightMap);

            //if (path.Count >= 300)
            //    path = pathFinder.RemoveEverySecondPoint(path);
            return path;
        }
        public static void DisposeUnitImage()
        {
            if (unitImage != null)
            {
                unitImage.Dispose();
                unitImage = null;
            }
        }
        public Mine GetRandomMine(List<Mine> mines)
        {
            Random random = new Random();
            return mines[random.Next(0, mines.Count)];
        }
        public void Draw(Graphics graphics)
        {
            if (unitImage != null && !IsInsideMine) // Проверяем, не находится ли юнит внутри шахты
            {
                int drawX = position.X;
                int drawY = position.Y + 15;
                graphics.DrawImage(unitImage, drawX, drawY, 30, 30);
            }
        }

    }
}
