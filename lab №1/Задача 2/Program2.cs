using System;
class Program
{
    static void Main()
    {
        int x, y;
        int r = 5;
        int x1 = 0, x2 = 0, x3 = -10;
        int y1 = 5, y2 = -5, y3 = 0;
        double centerY = 0, centerX = 5;

        checkNum(out x, "x: ");
        checkNum(out y, "y: ");
        bool isFallsCircle = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY) <= r * r;
        bool isFallsTriangle = (x - x1) * (y2 - y1) - (y - y1) * (x2 - x1) >= 0
                            && (x - x2) * (y3 - y2) - (y - y2) * (x3 - x2) >= 0
                            && (x - x3) * (y1 - y3) - (y - y3) * (x1 - x3) >= 0;
        bool isFallsShape = isFallsCircle || isFallsTriangle;
        Console.WriteLine("Точка попадает в фигуру: " + isFallsShape);
        Console.WriteLine("Точка попадает в окружность: " + isFallsCircle);
        Console.WriteLine("Точка попадает в треугольник: " + isFallsTriangle);
    }


    static void checkNum(out int a, string inf)
    {
        bool isRight = false;
        a = 0;

        while (!isRight)
        {
            Console.Clear();
            Console.Write("Введите значение " + inf);
            string num = Console.ReadLine();

            try
            {
                a = int.Parse(num);
                isRight = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите целое число. Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
            }
        }
    }
}