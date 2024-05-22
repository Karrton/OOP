using LabLibrary;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNewCollection collection1 = new MyNewCollection();
            collection1.CollectionName = "Collection1";

            MyNewCollection collection2 = new MyNewCollection();
            collection2.CollectionName = "Collection2";

            // Создаем два журнала
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            // Подписываем журналы на события коллекций
            collection1.CollectionCountChanged += (sender, e) =>
            {
                journal1.AddEntry(new JournalEntry(e.CollectionName, e.ChangeType, $"Элементов в дереве - {e.AffectedObject}"));
            };

            collection1.CollectionReferenceChanged += (sender, e) =>
            {
                journal2.AddEntry(new JournalEntry(e.CollectionName, e.ChangeType, e.AffectedObject.ToString()));
            };

            collection2.CollectionReferenceChanged += (sender, e) =>
            {
                journal2.AddEntry(new JournalEntry(e.CollectionName, e.ChangeType, e.AffectedObject.ToString()));
            };

            collection1.AddDefaults(10);
            collection2.AddDefaults(8);

            Console.WriteLine("Collection 1:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Collection 2:");
            foreach (var item in collection2)
            {
                item.Show();
            }

            Console.WriteLine();

            // Удаляем элементы из коллекций
            collection1.Remove(7);

            // Присваиваем новые значения некоторым элементам коллекций
            Challenge buff = new Challenge();
            buff.RandomInit();
            collection1[0] = (Challenge)buff.Clone();
            buff.RandomInit();
            collection1.Add((Challenge)buff.Clone());
            buff.RandomInit();
            collection2[3] = (Challenge)buff.Clone();

            collection1.Remove(5);

            // Выводим данные обоих журналов
            Console.WriteLine(journal1);
            Console.WriteLine(journal2);

            Console.WriteLine("Collection 1:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Collection 2:");
            foreach (var item in collection2)
            {
                item.Show();
            }
        }
    }
}