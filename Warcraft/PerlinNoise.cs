using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft
{
    class PerlinNoise
    {
        // Размеры решетки для шума Перлина
        private int gridSizeX;
        private int gridSizeY;
        // Градиенты для узлов решетки
        private float[,] gradientsX;
        private float[,] gradientsY;
        private Random random;
        public PerlinNoise(int gridSizeX, int gridSizeY, int seed = 0)
        {
            this.gridSizeX = gridSizeX;
            this.gridSizeY = gridSizeY;
            random = new Random(seed);

            gradientsX = new float[gridSizeX, gridSizeY];
            gradientsY = new float[gridSizeX, gridSizeY];

            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    // Генерируем случайные градиенты в пределах от -1 до 1
                    gradientsX[i, j] = (float)(random.NextDouble() * 2 - 1);
                    gradientsY[i, j] = (float)(random.NextDouble() * 2 - 1);
                    // Нормализация градиентов
                    float length = (float)Math.Sqrt(gradientsX[i, j] * gradientsX[i, j] + gradientsY[i, j] * gradientsY[i, j]);
                    gradientsX[i, j] /= length;
                    gradientsY[i, j] /= length;
                }
            }
        }
        private float Interpolate(float a, float b, float t)
        {
            float ft = t * t * (3.0f - 2.0f * t);
            return a * (1 - ft) + b * ft;
        }
        // Вычисление шума Перлина в точке (x, y)
        public float Noise(float x, float y)
        {
            // Определяем узлы решетки, в которых находится точка
            int x0 = (int)Math.Floor(x) % gridSizeX;
            int y0 = (int)Math.Floor(y) % gridSizeY;
            int x1 = (x0 + 1) % gridSizeX;
            int y1 = (y0 + 1) % gridSizeY;

            // Вычисляем местоположение точки относительно узлов
            float tx = x - (float)Math.Floor(x);
            float ty = y - (float)Math.Floor(y);

            // Вычисляем вклад градиентов от соседних узлов
            float dot00 = gradientsX[x0, y0] * tx + gradientsY[x0, y0] * ty;
            float dot10 = gradientsX[x1, y0] * (tx - 1) + gradientsY[x1, y0] * ty;
            float dot01 = gradientsX[x0, y1] * tx + gradientsY[x0, y1] * (ty - 1);
            float dot11 = gradientsX[x1, y1] * (tx - 1) + gradientsY[x1, y1] * (ty - 1);

            // Интерполируем между вкладом градиентов
            float interpolatedX0 = Interpolate(dot00, dot10, tx);
            float interpolatedX1 = Interpolate(dot01, dot11, tx);

            return Interpolate(interpolatedX0, interpolatedX1, ty);
        }
        public void FillNoiseArray(float[,] noiseArray, float scale)
        {
            int width = noiseArray.GetLength(0);
            int height = noiseArray.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Вычисляем шум в текущей точке с учетом масштаба
                    float x = i / scale;
                    float y = j / scale;
                    noiseArray[i, j] = Noise(x, y);
                }
            }
        }
    }
}
