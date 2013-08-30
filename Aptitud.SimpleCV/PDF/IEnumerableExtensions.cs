using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptitud.SimpleCV.PDF
{
    public static class IEnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> ie, Action<T, int, int> action)
        {
            var size = ie.ToList().Count;
            var i = 0;
            foreach (var e in ie) action(e, i++, size);
        }

    }
}
