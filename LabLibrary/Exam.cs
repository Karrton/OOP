using LabLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    [Serializable]
    public class Exam : Test, IInit, ICloneable
    {
        private string name;

        public Challenge BaseObject { get { return new Challenge(subject); } }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                name = value;
            }
        }

        public Exam(string subject, int score, string name) : base(subject, score)
        {
            Name = name;
        }

        public static string[] _Name(string[] firstNames, string[] lastNames)
        {
            List<string> combinations = new List<string>();

            foreach (string firstName in firstNames)
            {
                foreach (string lastName in lastNames)
                {
                    string fullName = $"{firstName} {lastName}";
                    combinations.Add(fullName);
                }
            }

            return combinations.ToArray();
        }

        public Exam() : base()
        {
            name = "";
        }

        public override void Show()
        {
            Console.WriteLine($"Class: {GetType().Name}, Name: {Name}, Scope: {Scope}, Object: {Subject}");
        }

        public override string ToString()
        {
            return $"Class: {GetType().Name}, Name: {Name}, Scope: {Scope}, Object: {Subject}";
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Enter the student's first and last name: ");
            Name = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Name = GenerateRandomName();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Exam other = (Exam)obj;
            return base.Equals(obj) && name == other.name;
        }

        //public int CompareTo(Exam other)
        //{
        //    if (other is null)
        //        return 1;

        //    return String.Compare(this.Name, other.Name, StringComparison.Ordinal);
        //}

        public override object Clone()
        {
            Exam clone = new Exam(this.Subject, this.Scope, this.Name);
            return clone;
        }

        private string GenerateRandomName()
        {
            string[] firstNames = { "John", "Jane", "Alex", "Emily", "Michael", "Emma", "David", "Olivia", "Daniel", "Sophia" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            string firstName = firstNames[rand.Next(firstNames.Length)];
            string lastName = lastNames[rand.Next(lastNames.Length)];

            return $"{firstName} {lastName}";
        }

        public object ShallowCopy() { return (Exam)MemberwiseClone(); }
    }
}
