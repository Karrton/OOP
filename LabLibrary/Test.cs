using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    [Serializable]
    public class Test : Challenge, IInit
    {
        protected int scope;

        public Challenge BaseObject { get { return new Challenge(subject); } }

        public int Scope
        {
            get { return scope; }
            set
            {
                if (value < 0 && value > 100) throw new ArgumentOutOfRangeException("value");
                scope = value;
            }
        }

        public Test(string subject, int score) : base(subject) { Scope = score; }

        public Test() : base() { scope = 0; }

        public override void Show()
        {
            Console.WriteLine($"Class: {GetType().Name}, Scope: {scope}, Object: {subject}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Enter the scope: ");
            scope = int.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Scope = rand.Next(1, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Test other = (Test)obj;
            return base.Equals(obj) && scope == other.scope;
        }

        public override string ToString()
        {
            return $"Class: {GetType().Name}, Scope: {scope}, Object: {subject}";
        }

        public override object Clone()
        {
            Test clone = new Test();
            clone.Subject = this.Subject;
            clone.Scope = this.Scope;
            return clone;
        }

        public object ShallowCopy() { return (Test)MemberwiseClone(); }
    }
}
