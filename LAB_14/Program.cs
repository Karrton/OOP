using LabLibrary;
class Program
{
    public class ChallengeComparer : IEqualityComparer<Challenge>
    {
        public bool Equals(Challenge x, Challenge y)
        {
            return x.Subject == y.Subject;
        }

        public int GetHashCode(Challenge obj)
        {
            return obj.Subject.GetHashCode();
        }
    }

    public class GenericCollection
    {
        public Stack<Dictionary<string, Challenge>> recordBook {  get; set; }
        static private Random rnd = new Random();

        public GenericCollection()
        {
            recordBook = new Stack<Dictionary<string, Challenge>>();
        }

        public GenericCollection(int capacity)
        {
            Challenge challenge = new Challenge();
            recordBook = new Stack<Dictionary<string, Challenge>>();

            for (int i = 0; i < capacity; i++) 
            {
                Dictionary<string, Challenge> temp = new Dictionary<string, Challenge>();
                for (int j = 0; j < rnd.Next(1, 8); j++)
                {
                    int rand = rnd.Next(1, 4);
                    switch (rand)
                    {
                        case 0: challenge = new Challenge(); break;
                        case 1: challenge = new Exam(); break;
                        case 2: challenge = new FinalExam(); break;
                        case 3: challenge = new Test(); break;
                    }

                    challenge.RandomInit();
                    Challenge buff = (Challenge)challenge.Clone();
                    buff.Subject = buff.Subject.Substring(0, buff.Subject.IndexOf("_"));
                    temp.Add(challenge.Subject, (Challenge)buff.Clone());
                }
                recordBook.Push(temp);
            }
            challenge.ResetCounter();
        }

        public void Show()
        {
            int num = 1;
            foreach (var semester in recordBook)
            {
                Console.WriteLine($"В зачётной книжке под номером {num++} хранится:");
                foreach (var kvp in semester)
                {
                    Console.WriteLine($"Ключ: {kvp.Key} Данные: {kvp.Value.ToString()}");
                }
            }
        }

        public void DataSampling(string subject)
        {
            var finals = recordBook.SelectMany(semester => semester)
                                   .Where(kvp => kvp.Key.Contains(subject))
                                   .Select(kvp => kvp.Value);
            Console.WriteLine($"Результаты экзаменов \"{subject}\":");
            foreach (var challenge in finals)
            {
                Console.WriteLine(challenge);
            }
        }

        public int GettingCounter(string subject)
        {
            var finals = recordBook.SelectMany(semester => semester)
                       .Where(kvp => kvp.Key.Contains(subject))
                       .Select(kvp => kvp.Value);
            return finals.Count();
        }

        public void Intersection(GenericCollection temp)
        {
            var intersection = recordBook
                                .SelectMany(semester => semester.Values)
                                .Intersect(temp.recordBook.SelectMany(semester => semester.Values), new ChallengeComparer())
                                .ToDictionary(challenge => challenge.Subject, challenge => challenge);

            Console.WriteLine("Пересечение множеств:");
            foreach (var kvp in intersection)
            {
                Console.WriteLine($"Предмет: {kvp.Key}, Данные: {kvp.Value.ToString()}");
            }
        }

        public void Except(GenericCollection temp)
        {
            var intersection = recordBook
                                .SelectMany(semester => semester.Values)
                                .Except(temp.recordBook.SelectMany(semester => semester.Values), new ChallengeComparer())
                                .ToDictionary(challenge => challenge.Subject, challenge => challenge);

            Console.WriteLine("Разность множеств:");
            foreach (var kvp in intersection)
            {
                Console.WriteLine($"Предмет: {kvp.Key}, Данные: {kvp.Value.ToString()}");
            }
        }

        public void Union(GenericCollection temp)
        {
            var union = recordBook.SelectMany(semester => semester)
                                  .Concat(temp.recordBook.SelectMany(semester => semester))
                                  .GroupBy(kvp => kvp.Key)
                                  .ToDictionary(group => group.Key, group => group.First().Value);
            Console.WriteLine("Объединение множеств:");
            foreach (var kvp in union)
            {
                Console.WriteLine($"Ключ: {kvp.Key}, Данные: {kvp.Value.ToString()}");
            }
        }

        public void GroupBy(GenericCollection temp)
        {
            var group = recordBook.SelectMany(semester => semester)
                                  .Concat(temp.recordBook.SelectMany(semester => semester))
                                  .GroupBy(kvp => ((Test)kvp.Value).Scope > 80);

            foreach (var grp in group)
            {
                Console.WriteLine("Данные:");

                foreach (var kvp in grp)
                {
                    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                }
            }
        }
    }
    static int Main()
    {
        string temp = "Math";
        GenericCollection genericCollection = new GenericCollection(2);
        GenericCollection genericCollection1 = new GenericCollection(2);
        Console.WriteLine("==========Коллекция 1==========");
        genericCollection.Show();
        Console.WriteLine("==========Коллекция 2==========");
        genericCollection1.Show();
        Console.WriteLine("==========Выборка данных==========");
        genericCollection.DataSampling(temp);
        Console.WriteLine("==========Получение счетчика==========");
        Console.WriteLine($"Элементов с полем {temp} содержится в коллекции {genericCollection.GettingCounter("Math")}");
        Console.WriteLine("==========Действия над множествами==========");
        genericCollection.Except(genericCollection1);
        genericCollection.Union(genericCollection1);
        genericCollection.Intersection(genericCollection1);
        Console.WriteLine("==========Агрегация==========");
        var totalScore = genericCollection.recordBook.SelectMany(dict => dict.Values).Average((chall => ((Test)chall).Scope));
        Console.WriteLine(totalScore.ToString());
        Console.WriteLine("==========Группировка==========");
        genericCollection.GroupBy(genericCollection1);

        return 0;
    }
}

