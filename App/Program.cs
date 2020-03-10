using Niipazzo.Exercises;
using Niipazzo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var c = new CheckPermutation("iddqd", "iqddddddddddddddddddd");
            c.Solve();
            Console.WriteLine(c.Result);

            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
