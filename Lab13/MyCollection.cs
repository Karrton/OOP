using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class MyCollection : Tree<Challenge>
    {
        public MyCollection() : base() { }

        public MyCollection(int capacity) : base(capacity) { }

        public virtual void AddRandomCollection(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                this.Add((Challenge)GetChallenge().Clone());
            }
        }

        public virtual void AddInitCollection(int capacity) 
        {
            for (int i = 0; i < capacity; i++)
            {
                Challenge temp = GetChallenge();
                temp.Init();
                this.Add((Challenge)temp.Clone());
            }
        }

        public virtual bool RemoveElementCollection()
        {
            bool isRemove = false;
            List<Challenge> temp = TreeToList(this);
            string input = null;

            Console.Clear();
            Console.WriteLine("Какой элемент удалить?");
            int ord = 0;
            foreach (var item in this)
            {
                ++ord;
                Console.WriteLine($"{ord}.{item}");
            }
            input = Console.ReadLine();
            int num = int.Parse(input);
            if (num > this.Count || num < 1)
            {
                Console.WriteLine("Элемент под данным номером удалить не получилось!");
            }
            else
            {
                this.RemoveNode((Challenge)temp.ElementAt(--num).Clone());
                isRemove = true;
                Console.WriteLine("Удаление завершено");
            }
            Thread.Sleep(1500);
            Console.Clear();
            return isRemove;
        }

        public virtual void RemoveCollection()
        {
            this.DeleteTree();
            Console.WriteLine("Узлы дерева были удалены!");
            Thread.Sleep(1500);
            Console.Clear();
        }

        private static Challenge GetChallenge()
        {
            Challenge temp = null;
            int rand = rnd.Next(0, 4);
            switch (rand)
            {
                case 0: temp = new Challenge(); break;
                case 1: temp = new Exam(); break;
                case 2: temp = new FinalExam(); break;
                case 3: temp = new Test(); break;
            }

            temp.RandomInit();
            return temp;
        }
    }
}
