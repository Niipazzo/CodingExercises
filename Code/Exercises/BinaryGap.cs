using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niipazzo.Exercises
{
    public static class BinaryGap
    {
        public static int Solve(int n)
        {
            var bits = Convert.ToString(n, 2);
            var groups = bits.Split('1').Skip(1).SkipLast(1).ToList();
            groups.Add(string.Empty);
            var gap = groups.Max(x => x.Length);
            return gap;
        }
    }
}
