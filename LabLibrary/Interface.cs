using LabLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabLibrary
{
    public interface IInit
    {
        void Init();
        void RandomInit();
        void Show();
    }

    public class Other : IComparer
    {
        public int Compare(object x, object y)
        {
            int subjectComparison = String.Compare(((Challenge)x).Subject, ((Challenge)y).Subject, StringComparison.Ordinal);

            if (subjectComparison != 0) return subjectComparison;

            if (x as Test != null && y as Test != null)
            {
                int scopeComparison = ((Test)x).Scope.CompareTo(((Test)y).Scope);
                if (scopeComparison != 0)
                    return scopeComparison;
            }

            return 0;
        }

        public static Challenge BinarySearch(Challenge[] array, string subject)
        {

            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {

                int mid = (min + max) / 2;

                int compare = subject.CompareTo(array[mid].Subject);

                if (compare == 0)
                {
                    return array[mid];
                }
                else if (compare < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

            }

            return null;
        }
    }
}
