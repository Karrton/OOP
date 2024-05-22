using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LabLibrary
{
    [JsonDerivedType(typeof(Challenge), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(Test), typeDiscriminator: "Test")]
    [JsonDerivedType(typeof(Exam), typeDiscriminator: "Exam")]
    [JsonDerivedType(typeof(FinalExam), typeDiscriminator: "FinalExam")]
    [Serializable]
    [XmlInclude(typeof(Test)),
     XmlInclude(typeof(Exam)),
     XmlInclude(typeof(FinalExam)),
     XmlType]
    public class Challenge : IInit, ICloneable, IComparable<Challenge>
    {
        [NonSerialized]
        protected Random rand = new Random();
        protected static int subjectCounter = 0;
        protected string subject;

        public string Subject
        {
            get => subject;
            set => subject = value;
        }

        public int SubjectCounter
        {
            get => subjectCounter; set => subjectCounter = value;
        }

        public static int GetCount()
        {
            return subjectCounter;
        }

        public void ResetCounter() => subjectCounter = 0;
        public Challenge()
        {
            subject = "";
            ++SubjectCounter;
        }

        public Challenge(string subject)
        {
            Subject = subject;
            ++SubjectCounter;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Class: {GetType().Name}, Object: {subject}");
        }

        public virtual void Init()
        {
            Console.Write("Enter subject: ");
            Subject = Console.ReadLine();
        }

        public virtual void RandomInit() => Subject = GenerateRandomSubjectName();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Challenge other = (Challenge)obj;
            return subject == other.subject;
        }

        public string GenerateRandomSubjectName()
        {
            string[] subjects = { "Math", "Physics", "Chemistry", "Biology", "History", "English", "Computer Science", "Geography", "Literature", "Music" };
            return subjects[rand.Next(subjects.Length)] + "_" + subjectCounter;
        }

        public int CompareTo(Challenge? other)
        {
            if (other is null)
                return 1;

            return String.Compare(this.Subject, other.Subject, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"Class: {GetType().Name}, Object: {subject}";
        }

        public virtual object Clone()
        {
            Challenge clone = new Challenge();
            clone.Subject = Subject;
            return clone;
        }

        public object ShallowCopy() => (Challenge)MemberwiseClone();
    }
}