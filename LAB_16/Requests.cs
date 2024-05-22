using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_16
{
    public static class Requests
    {
        public static IEnumerable<Challenge> FilterBySubject(this IEnumerable<Challenge> challenges, Func<string, bool> predicate)
        {
            return from challenge in challenges
                   where predicate(challenge.Subject)
                   select challenge;
        }

        public static IEnumerable<Challenge> FilterByType(this IEnumerable<Challenge> challenges, Func<Challenge, bool> predicate)
        {
            return challenges.Where(predicate);
        }

        public static IEnumerable<Challenge> GroupByTypeAndSortDescending(this IEnumerable<Challenge> challenges, Func<Challenge, object> orderBySelector)
        {
            return challenges.GroupBy(challenge => challenge.GetType())
                             .SelectMany(group => group.OrderByDescending(orderBySelector));
        }
    }
}
