using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;

namespace Warcraft
{
    public class Map
    {
        private int numParts;
        private Color[,] colorMap;
        public float[,] heightMap { get; }
        private Random random;
        public int Width { get; }
        public int Height { get; }
        private PerlinNoise perlinNoise { get; }
        public Map(int width, int height)
        {
            numParts = Environment.ProcessorCount;
            random = new Random();
            Width = width;
            Height = height;
            heightMap = new float[width, height];
            colorMap = new Color[width, height];
            perlinNoise = new PerlinNoise(width, height, random.Next(1, 99999));
        }
        public void GenerateMap(float scale)
        {
            perlinNoise.FillNoiseArray(heightMap, scale);
            FillColorMap(heightMap);
        }
        private Color GetColorFromHeight(float height)
        {
            if (height < -0.3f)
            {
                return Color.Blue; // Вода (низкая высота)
            }
            else if (height < -0.1f)
            {
                return Color.LightBlue; // Мелководье
            }
            else if (height < 0.2f)
            {
                return Color.Green; // Низина (зелёный цвет)
            }
            else if (height < 0.3f)
            {
                return Color.Yellow; // Равнина
            }
            else if (height < 0.45f)
            {
                return Color.Orange; // Низкие горы
            }
            else
            {
                return Color.Gray; // Высокие горы
            }
        }
        void FillColorMap(float[,] array)
        {
            List<Task> tasks = new List<Task>();

            for (int part = 0; part < numParts; part++)
            {
                int startRow = part * Height / numParts;
                int endRow = (part + 1) * Height / numParts;

                tasks.Add(Task.Run(() =>
                {
                    for (int x = 0; x < Width; x++)
                    {
                        for (int y = startRow; y < endRow; y++)
                        {
                            colorMap[x, y] = GetColorFromHeight(heightMap[x,y]);
                        }
                    }
                }));
            }
            Task.WhenAll(tasks).Wait();
        }
        public void Draw(Graphics graphics)
        {
            List<Task> tasks = new List<Task>();

            for (int part = 0; part < numParts; part++)
            {
                int startRow = part * Height / numParts;
                int endRow = (part + 1) * Height / numParts;

                tasks.Add(Task.Run(() =>
                {
                    using (var brush = new SolidBrush(Color.Empty))
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            int start = startRow;
                            Color currentColor = colorMap[x, startRow];

                            for (int y = startRow + 1; y <= endRow; y++)
                            {
                                if (y == endRow || colorMap[x, y] != currentColor)
                                {
                                    lock (graphics)
                                    {
                                        brush.Color = currentColor;
                                        graphics.FillRectangle(brush, x, start, 1, y - start);
                                    }
                                    if (y < endRow)
                                    {
                                        start = y;
                                        currentColor = colorMap[x, y];
                                    }
                                }
                            }
                        }
                    }
                }));
            }

            Task.WhenAll(tasks).Wait();
        }
        public Bitmap CreateMapBitmap()
        {
            Bitmap bitmap = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        Color color = GetColorFromHeight(heightMap[x, y]);
                        bitmap.SetPixel(x, y, color);
                    }
                }
            }

            return bitmap;
        }
    }
}
