using Niipazzo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Niipazzo.Exercises.One
{
    /// 1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
    /// cannot use additional data structures?
    /// 
    /// From book: Cracking coding interview by Gayle Laakmann 2016
    /// Page: 192
    public class IsUnique : IExercise
    {
        private string Value { get; }
        public bool Result { get; private set; } = false;

        public IsUnique(string value)
        {
            Value = value;
        }

        public void Render()
        {
            Console.WriteLine($"String provided {(Result ? "contains all unique chars" : "contains dublicate chars")}");
        }

        public void Solve()
        {
            Solve2();
        }

        //using Linq
        private void Solve1()
        {
            if (Value == null)
            {
                Result = true;
                return;
            }

            Result = Value.GroupBy(x => x).All(x => x.Count() == 1);
        }

        // using sort and loop
        private void Solve2()
        {
            if (Value == null)
            {
                Result = true;
                return;
            }

            var chars = Value.ToArray();
            Array.Sort(chars);

            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    Result = false;
                    return;
                }
            }

            Result = true;
        }

        public static void Test()
        {
            var numberOfRuns = 100;
            var length = 100000;
            var elapsedList = new List<long>(numberOfRuns);

            Enumerable.Range(1, numberOfRuns).ForEach(x =>
            {
                var randomString = Tools.String.RandomString(Tools.String.Alphanumeric, length);
                var elapsedMs = Metrics.Run(new IsUnique(randomString));
                elapsedList.Add(elapsedMs);
            });

            Console.WriteLine($"Average execution time: {elapsedList.Average()}ms");
        }
    }
}
