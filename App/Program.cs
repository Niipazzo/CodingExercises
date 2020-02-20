using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            var arr = list.ToArray();
            Console.WriteLine(arr[3]);
            Console.Read();
        }
    }
}
