using System;
class Program
{
    static double calculate(double a, double b)
    {
        return (Math.Pow(a - b, 3) - Math.Pow(a, 3)) / (-Math.Pow(b, 3) + 3 * a * Math.Pow(b, 2) - 3 * Math.Pow(a, 2) * b);
    }

    static float calculate(float a, float b)
    {
        return (float)((Math.Pow(a - b, 3) - Math.Pow(a, 3)) / (-Math.Pow(b, 3) + 3 * a * Math.Pow(b, 2) - 3 * Math.Pow(a, 2) * b));
    }

    static void Main()
    {
        float floatA = 1000;
        float floatB = 0.0001f;

        double doubleA = 1000;
        double doubleB = 0.0001;

        Console.WriteLine("Результат выражения (float): " + calculate(floatA, floatB));
        Console.WriteLine("Результат выражения (double): " + calculate(doubleA, doubleB));
    }
}