using System;
using System.Threading;
using LabLibrary;
using Lab12;

class Program
{
    static void Main()
    {
        Tree<Challenge> tree = new Tree<Challenge>();
        List<Challenge> list = new List<Challenge>();
        string input = null;
        int inputToInt = 0;
        Challenge temp = null;
        bool isCreate = false;
        bool isRight = false;

        while (true)
        {
            if (!isCreate)
            {
                Console.Clear();
                Console.WriteLine("1.Создать дерево\n2.Редактировать дерево\n3.Сбалансировать дерево\n" +
                    "4.Среднее арифметическое\n5.Печать дерева\n6.Печать дерева (foreach)");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("1.Редактировать дерево\n2.Сбалансировать дерево\n" +
                    "3.Найти высоту дерева\n4.Печать дерева\n5.Печать дерева (foreach)");
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            int keyToInt = (int)key.Key;
            if (isCreate) keyToInt++;
            else
            {
                if (keyToInt != 49)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Создайте древо, прежде чем с ним работать!");
                    keyToInt = 0;
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
            list = TreeToList(tree);
            Console.Clear();
            switch (keyToInt)
            {
                case 49:
                    isCreate = true;
                    while (true)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Сколько элементов сгенерировать?");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out inputToInt))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка ввода, число записано не верно!");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                        else if (int.Parse(input) < 0 || int.Parse(input) == 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка ввода, число не может быть отрицательным или равным нулю!");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                        else
                            break;
                    }
                    temp = null;
                    for (int i = 0; i < inputToInt; i++)
                    {
                        //tree.Add(Tree<Challenge>.GetChallenge());
                    }
                    break;
                case 50:
                    isRight = false;
                    do
                    {
                        Console.WriteLine("1.Изменить элемент\n2.Удалить элемент\n3.Добавить элемент\n");
                        key = Console.ReadKey(true);
                        keyToInt = (int)key.Key;
                    switch (keyToInt)
                    {
                        case 49:
                            if (tree.Count <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Дерево пустое, удаление невозможно!");
                                Thread.Sleep(1500);
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine("Какой элемент изменить?:");
                            inputToInt = 0;
                            foreach (var item in tree)
                            {
                                ++inputToInt;
                                Console.WriteLine($"{inputToInt}.{item}");
                            }
                            input = Console.ReadLine();
                            inputToInt = int.Parse(input);

                            // Поверхностное копирование
                            Tree<Challenge> shallowCopyTree = tree.ShallowCopy();

                            // Клонирование
                            Tree<Challenge> clonedTree = new Tree<Challenge>(tree);

                            //Challenge challenge = Tree<Challenge>.GetChallenge();
                            Console.Clear();
                            //Console.WriteLine($"Элемент {list.ElementAt(--inputToInt)}\nЗаменён на {challenge}\n");

                            //tree.Search(list.ElementAt(inputToInt)).SetData(challenge);

                            inputToInt = 0;

                            Console.WriteLine("Изменения в оригинальном дереве:");
                            foreach (var item in tree)
                            {
                                ++inputToInt;
                                Console.WriteLine($"{inputToInt}.{item}");
                            }

                            inputToInt = 0;
                            Console.WriteLine("\nИзменения в поверхностной копии:");
                            foreach (var item in shallowCopyTree)
                            {
                                ++inputToInt;
                                Console.WriteLine($"{inputToInt}.{item}");
                            }

                            inputToInt = 0;
                            Console.WriteLine("\nИзменения в клоне:");
                            foreach (var item in clonedTree)
                            {
                                ++inputToInt;
                                Console.WriteLine($"{inputToInt}.{item}");
                            }
                            ShowEnd();
                            isRight = true;
                            break;
                        case 50:
                            if(tree.Count <= 0)
                            {
                                    Console.Clear();
                                    Console.WriteLine("Дерево пустое, удаление невозможно!");
                                    Thread.Sleep(1500);
                                    break;
                            }
                            Console.Clear();
                            Console.WriteLine("Какой элемент удалить?");
                            int ord = 0;
                            foreach (var item in tree)
                            {
                                ++ord;
                                Console.WriteLine($"{ord}.{item}");
                            }
                            input = Console.ReadLine();
                            int buff = int.Parse(input);
                            tree.RemoveNode(list.ElementAt(--buff));
                            Console.Clear();
                            Console.WriteLine("Удаление завершено");
                            Thread.Sleep(1500);
                            isRight = true;
                            break;
                        case 51:
                                isRight = false;
                                do {
                                    Console.Clear();
                                    Console.WriteLine("Объект какого типа добавить?" +
                                        "\n1.Challenge\n2.Exam\n3.FinalExam\n4.Test");
                                    key = Console.ReadKey(true);
                                    keyToInt = (int)key.Key;
                                    if (keyToInt < 1 || keyToInt > 4)
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Нет такой операции!");
                                        Console.ResetColor();
                                        Thread.Sleep(1500);
                                    }
                                    else
                                        isRight = true;
                                } while (!isRight);
                            temp = null;
                            switch (keyToInt)
                            {
                                
                                case 49: temp = new Challenge(); break;
                                case 50: temp = new Exam(); break;
                                case 51: temp = new FinalExam(); break;
                                case 52: temp = new Test(); break;
                            }
                            Console.Clear();
                            temp.Init();
                            tree.Add(temp);
                            Console.Clear();
                            Console.WriteLine("Добавлен элемент:");
                            temp.Show();
                            Thread.Sleep(3000);
                            isRight = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Нет такой операции!");
                            Console.ResetColor();
                            break;
                    }
                    } while (!isRight);
                    break;
                case 51:
                    foreach (var item in tree)
                    {
                        list.Add(item);
                    }
                    list.Sort();
                    tree.BuildBalancedTree(list);
                    Console.WriteLine("Балансировка выполнена успешно");
                    ShowEnd();
                    break;
                case 52:
                    Console.WriteLine("Высота дерева: " + tree.Height());
                    ShowEnd();
                    break;
                case 53:
                    tree.PrintTree();
                    ShowEnd();
                    break;
                case 54:
                    Console.WriteLine("Обход оп порядку:");
                    foreach (var item in tree)
                    {
                        item.Show();
                    }
                    ShowEnd();
                    break;
            }
        }
    }

    static List<Challenge> TreeToList(Tree<Challenge> tree)
    {
        List<Challenge> list = new List<Challenge>();
        foreach (var item in tree)
        {
            list.Add((Challenge)item.Clone());
        }
        return list;
    }

    static void ShowEnd()
    {
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
        Console.ReadKey(true);
    }
}