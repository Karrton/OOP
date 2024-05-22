using LabLibrary;
using System;

namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public object AffectedObject { get; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object affectedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            AffectedObject = affectedObject;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Affected Object: {AffectedObject}";
        }
    }

    public class MyNewCollection : MyCollection
    {
        public event EventHandler<CollectionHandlerEventArgs> CollectionChanged;
        public event EventHandler<CollectionHandlerEventArgs> CollectionCountChanged;
        public event EventHandler<CollectionHandlerEventArgs> CollectionReferenceChanged;

        public string CollectionName { get; set; }

        public MyNewCollection() : base() { }

        public MyNewCollection(int capacity) : base(capacity) { }

        public override void AddRandomCollection(int capacity)
        {
            base.AddRandomCollection(capacity);
            OnCollectionChanged("AddRandom", this.Count);
            OnCollectionCountChanged("AddRandom", this.Count);
        }

        public override void AddInitCollection(int capacity)
        {
            base.AddInitCollection(capacity);
            OnCollectionChanged("AddInit", this.Count);
            OnCollectionCountChanged("AddInit", this.Count);
        }

        public override bool RemoveElementCollection()
        {
            bool isRemoved = base.RemoveElementCollection();
            if (isRemoved)
            {
                OnCollectionChanged("RemoveElement", isRemoved);
                OnCollectionCountChanged("RemoveElement", this.Count);
            }
            return isRemoved;
        }

        public override void RemoveCollection()
        {
            base.RemoveCollection();
            OnCollectionChanged("RemoveCollection", this.Count);
            OnCollectionCountChanged("RemoveCollection", this.Count);
        }

        public bool RemoveElement(int j)
        {
            if (j >= 0 && j < this.Count)
            {
                OnCollectionChanged("Remove", (Challenge)this[j].Clone());
                this.Remove((Challenge)this[j].Clone());
                return true;
            }
            return false;
        }

        public override Challenge this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Count)
                    return (Challenge)base[index].Clone();
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < this.Count)
                {
                    base[index] = value;
                    OnCollectionChanged("Set", index);
                    OnCollectionReferenceChanged("Set", value.ToString());
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }

        private void OnCollectionChanged(string changeType, object affectedObject)
        {
            CollectionChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, changeType, affectedObject));
        }

        private void OnCollectionCountChanged(string changeType, object affectedObject)
        {
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, changeType, affectedObject));
        }

        private void OnCollectionReferenceChanged(string changeType, object affectedObject)
        {
            CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, changeType, affectedObject));
        }

        public void AddDefaults(int capacity)
        {
            base.AddRandomCollection(capacity);
            OnCollectionCountChanged("AddDefaults", this.Count);
        }

        public void Add(params object[] items)
        {
            foreach (var item in items)
            {
                base.Add((Challenge)item);
            }
            OnCollectionCountChanged("Add", this.Count);
        }

        public void Remove(int index)
        {
            if (RemoveElement(index))
                OnCollectionCountChanged("Remove", this.Count);
        }
    }

    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string Data { get; set; }

        public JournalEntry(string collectionName, string changeType, string data)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            Data = data;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Data: {Data}";
        }
    }

    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void AddEntry(JournalEntry entry)
        {
            entries.Add(entry);
        }

        public override string ToString()
        {
            string result = "Journal Entries:\n";
            foreach (var entry in entries)
            {
                result += entry.ToString() + "\n";
            }
            return result;
        }
    }
}
