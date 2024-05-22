using Lab12;
using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_16
{
    public class Controller
    {
        private Tree<Challenge> collection;

        public Controller()
        {
            collection = new Tree<Challenge>();
        }

        public bool CollectionExists()
        {
            return collection.Count == 0 || collection == null;
        }

        public IEnumerable<Challenge> Get()
        {
            return collection;
        }

        public void AddData(Challenge challenge)
        {
            collection.AddNode(challenge);
        }

        public void SaveToXml(string filePath)
        {
            collection.SerializeToXml(filePath);
        }

        public void SaveToJson(string filePath)
        {
            collection.SerializeToJson(filePath);
        }

        public void SaveToBinary(string filePath)
        {
            collection.SerializeToBinary(filePath);
        }

        public void LoadFromXml(string filePath)
        {
            collection.DeserializeFromXml(filePath);
        }

        public void LoadFromJson(string filePath)
        {
            collection.DeserializeFromJson(filePath);
        }

        public void LoadFromBinary(string filePath)
        {
            collection.DeserializeFromBinary(filePath);
        }

        public void DeleteElements(List<Challenge> listForDeleting)
        {
            foreach (var item in listForDeleting)
                collection.RemoveNode(item);
        }

        public Challenge ElementAt(int index)
        {
            return (Challenge)collection.ElementAt(index).Clone();
        }

        public void ChangeChallenge(Challenge newChallenge, Challenge oldChallenge)
        {
            if (newChallenge.Equals(oldChallenge))
                return;

            collection.RemoveNode(oldChallenge);
            collection.AddNode(newChallenge);
        }

        public void GenerateRandomData(int count)
        {
            int initialCount = collection.Count + count;
            while (initialCount != collection.Count)
            {
                try
                {
                    collection.AddNode(Tree<Challenge>.GetChallenge());
                }
                catch (Exception) { }
            }
        }

        public void GenerateData<T>(int count) where T : Challenge, new()
        {
            int initialCount = collection.Count + count;
            while (initialCount != collection.Count)
            {
                try
                {
                    T elem = new T();
                    elem.RandomInit();
                    collection.AddNode(elem);
                }
                catch (Exception) { }
            }
        }

        public IEnumerable<Challenge> FilterByType(string find)
        {
            return collection.Where(challenge => challenge.Subject == "find");
        }

        public IEnumerable<Challenge> SortBySubject()
        {
            return collection.OrderBy(challenge => challenge.Subject);
        }
    }
}
