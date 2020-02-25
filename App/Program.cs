using Niipazzo.Exercises;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var small = "abbc";
            var big = "cbabadcbbabbcbabaabccbabc";
            var obj = new StringPermutations(small, big);
            obj.Solve();
            Console.Read();
        }
    }
}
