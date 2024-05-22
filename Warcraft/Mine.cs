using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft
{
    public class Mine
    {
        public Point Location { get; private set; }
        public int Gold { get; private set; }
        private static Image mineImage;
        public static List<Mine> mines = new List<Mine>();
        private static HashSet<Point> mineLocations = new HashSet<Point>();
        public Mine(Point location, int initialGold)
        {
            Location = location;
            Gold = initialGold;

            if (mineImage == null)
            {
                mineImage = Image.FromFile("C:\\Users\\Dreamer\\Desktop\\Лабораторные и прочее\\ООП\\Warcraft\\mine.png");
            }
        }
        public int MineGold(int amount)
        {
            if (Gold > 0)
            {
                int goldToMine = Math.Min(Gold, amount);
                Gold -= goldToMine;

                CheckAndRemoveEmptyMine();

                return goldToMine;
            }
            return 0;
        }
        private void CheckAndRemoveEmptyMine()
        {
            if (Gold <= 0)
            {
                mines.Remove(this);
                mineLocations.Remove(Location);
            }
        }
        public void GenerateMines(int numMines, int initialGold, float[,] heightMap)
        {
            Random random = new Random();
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);
            int minesGenerated = 0;

            while (minesGenerated < numMines)
            {
                int x = random.Next(50, width - 50);
                int y = random.Next(50, height - 50);

                float heightValue = heightMap[x, y];

                if (heightValue >= 0.3f && heightValue <= 0.45f)
                {
                    Point potentialLocation = new Point(x, y);

                    if (!mineLocations.Contains(potentialLocation))
                    {
                        Mine newMine = new Mine(potentialLocation, initialGold);
                        mines.Add(newMine);
                        mineLocations.Add(potentialLocation);
                        minesGenerated++;
                    }
                }
            }
        }
        public void Draw(Graphics graphics)
        {
            foreach (var mine in mines)
            {
                if (mineImage != null)
                {
                    graphics.DrawImage(mineImage, mine.Location.X, mine.Location.Y);
                }
            }
        }
        public static void DisposeMineImage()
        {
            if (mineImage != null)
            {
                mineImage.Dispose();
                mineImage = null;
            }
        }
        public List<Mine> GetMines()
        {
            return mines;
        }
    }
}
