using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft
{
    public class TownHall
    {
        public Point Position { get; private set; }
        public int GoldStorage { get; private set; }
        public int RestTime { get; private set; }
        private static Image hallImage;
        public TownHall(Point initialPosition, int restTime)
        {
            Position = initialPosition;
            GoldStorage = 0;
            RestTime = restTime;

            if (hallImage == null)
            {
                hallImage = Image.FromFile("C:\\Users\\Dreamer\\Desktop\\Лабораторные и прочее\\ООП\\Warcraft\\hall.png");
            }
        }
        public void AddGold(int goldAmount)
        {
            GoldStorage += goldAmount;
        }
        public void GenerateTownHall(float[,] heightMap, int width, int height, int restTime, Random random)
        {
            Point townHallPosition = Point.Empty;
            bool foundSuitableLocation = false;
            List<Point> potentialLocations = new List<Point>();

            for (int x = 50; x < width - 50; x++)
            {
                for (int y = 50; y < height - 50; y++)
                {
                    float heightValue = heightMap[x, y];

                    // Ратуша должна появляться на равнине у воды
                    if (heightValue >= -0.1f && heightValue <= 0.2f)
                    {
                        potentialLocations.Add(new Point(x, y));
                    }
                }
            }

            if (potentialLocations.Count > 0)
            {
                int index = random.Next(potentialLocations.Count);
                townHallPosition = potentialLocations[index];
                foundSuitableLocation = true;
            }

            if (foundSuitableLocation)
            {
                Position = townHallPosition;
                RestTime = restTime;
            }

            Position = new Point(random.Next(50, 800 - 50), random.Next(50, 800 - 50));
            RestTime = 1000;
        }
        public void RestUnit(Unit unit)
        {
            // Здесь можно реализовать отдых юнита
            System.Threading.Thread.Sleep(RestTime);
        }
        public void Draw(Graphics graphics)
        {
            if (hallImage != null)
            {
                graphics.DrawImage(hallImage, Position.X, Position.Y);
            }
        }
        public static void DisposehallImage()
        {
            if (hallImage != null)
            {
                hallImage.Dispose();
                hallImage = null;
            }
        }
    }
}
