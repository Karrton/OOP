using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int m, n;
        double x = 0;
        bool isRight = false;

        InputNumbers(out m, "m: ");
        InputNumbers(out n, "n: ");
        Console.WriteLine("Выражение m+--n при m = " + m + " и n = " + n + " равно - " + (m + --n));
        OutInformation();

        InputNumbers(out m, "m: ");
        InputNumbers(out n, "n: ");
        Console.WriteLine("Выражение m++<--n при m = " + m + " и n = " + n + " принимает значение - " + (m++ < --n));
        OutInformation();

        InputNumbers(out m, "m: ");
        InputNumbers(out n, "n: ");
        Console.WriteLine("Выражение --m>n—- при m = " + m + " и n = " + n + " принимает значение - " + (--m > n--));
        OutInformation();

        while (!isRight)
        {
            InputNumbers(out x, "x: ");
            if (x + Math.Pow(x, 2) >= -1 && x + Math.Pow(x, 2) <= 1)
            {
                isRight = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод: x - не принадлежит диапазону от -1, до 1. Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
            }
        }

        double rez = Math.Acos(x + Math.Pow(x, 2));
        Console.WriteLine("Результат выражения arccos(x + x^2) при x = " + x + " равен " + rez);
    }

    static void OutInformation()
    {
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
        Console.ReadKey();
    }

    static void InputNumbers(out int a, string inf)
    {
        bool isRight = false;
        a = 0;
        while (!isRight)
        {
            Console.Clear();
            Console.Write("Введите целое число " + inf);
            string inLine1 = Console.ReadLine();

            try
            {
                a = int.Parse(inLine1);
                isRight = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите целое число. Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
            }
        }
    }

    static void InputNumbers(out double a, string inf)
    {
        bool isRight = false;
        a = 0;
        while (!isRight)
        {
            Console.Clear();
            Console.Write("Введите вещественное число " + inf);
            string inLine1 = Console.ReadLine();

            try
            {
                a = double.Parse(inLine1);
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