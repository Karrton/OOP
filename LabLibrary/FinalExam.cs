using LabLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace LabLibrary
{
    [Serializable]
    public class FinalExam : Exam, IInit, ICloneable
    {
        private int estimation;

        public Challenge BaseObject { get { return new Challenge(subject); } }

        public FinalExam(string subject, int score, string name, int estimation) : base(subject, score, name)
        {
            SetEstimation();
        }

        public FinalExam() : base()
        {
            estimation = 0;
        }

        public int Estimation
        {
            get { return estimation; }
            set { SetEstimation(); }
        }

        private void SetEstimation()
        {
            if (Scope > 90)
                estimation = 5;
            else if (Scope >= 80)
                estimation = 4;
            else if (Scope >= 70)
                estimation = 3;
            else
                estimation = 2;
        }

        public override void Show()
        {
            Console.WriteLine($"Class: {GetType().Name}, Name: {Name}, Scope: {Scope}, Object: {Subject}, Estimation: {estimation}");
        }

        public override string ToString()
        {
            return $"Class: {GetType().Name}, Name: {Name}, Scope: {Scope}, Object: {Subject}, Estimation: {estimation}";
        }

        public override void Init()
        {
            base.Init();
            SetEstimation();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            SetEstimation();
        }

        public override object Clone()
        {
            FinalExam clone = new FinalExam(this.Subject, this.Scope, this.Name, this.Estimation);
            return clone;
        }

        public object ShallowCopy() { return (FinalExam)MemberwiseClone(); }
    }
}
