using Niipazzo.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var o = new StringPermutations();
            //o.PrintOccurences = true;
            //o.SolveAndRender();
            StringPermutations.Test(100, "abc", 100);

            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
