using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Niipazzo.Tools;

namespace Niipazzo.Exercises
{
    /// Example: Given a smaller string 5 and a bigger string b, design an algorithm to find all permutations of the shorter string within the longer one.
    /// Print the location of each permutation
    /// 
    /// From book: Cracking coding interview by Gayle Laakmann 2016
    /// Page: 69
    public class StringPermutations : IExercise
    {
        private string Small { get; }
        private string Big { get; }
        public bool PrintOccurences { get; set; }

        private List<int> Result { get; set; }

        public StringPermutations(string small = null, string big = null, bool printOccurences = false)
        {
            //Init with example values from book
            Small = small ?? "abbc";
            Big = big ?? "cbabadcbbabbcbabaabccbabc";
            PrintOccurences = printOccurences;
        }

        public void SolveAndRender()
        {
            Solve();
            Render();
        }

        public void Solve()
        {
            //SolveUsingSortArrayAndSequenceEqual();
            SolveUsingSortArrayAndSelfCompare();
        }

        /// <summary>
        /// Validchars = "abc"
        /// Small.Length = 5
        /// Big.Length = 50Mil
        /// Avg execution is 8406ms
        /// </summary>
        private void SolveUsingSortArrayAndSequenceEqual()
        {
            var result = new List<int>();
            var smallSorted = Small.ToCharArray();
            var smallLength = Small.Length;
            Array.Sort(smallSorted);
            var loopEnd = Big.Length - smallLength;
            for (int i = 0; i <= loopEnd; i++)
            {
                var subStr = Big.Substring(i, smallLength).ToCharArray();
                Array.Sort(subStr);
                if (subStr.SequenceEqual(smallSorted))
                {
                    //start index of matching substr
                    result.Add(i);
                }
            }
            Result = result;
        }

        /// <summary>
        /// Validchars = "abc"
        /// Small.Length = 5
        /// Big.Length = 50Mil
        /// Avg execution is 4268ms
        /// </summary>
        private void SolveUsingSortArrayAndSelfCompare()
        {
            var result = new List<int>();
            var smallSorted = Small.ToCharArray();
            var smallLength = Small.Length;
            Array.Sort(smallSorted);
            var loopEnd = Big.Length - smallLength;
            for (int i = 0; i <= loopEnd; i++)
            {
                var subStr = Big.Substring(i, smallLength).ToCharArray();
                Array.Sort(subStr);

                var sequenceEqual = true;
                for (var j = 0; j < subStr.Length; j++)
                {
                    if (subStr[j] == smallSorted[j])
                        continue;

                    sequenceEqual = false;
                    break;
                }

                if (sequenceEqual)
                {
                    //start index of matching substr
                    result.Add(i);
                }
            }
            Result = result;
        }

        public void Render()
        {
            if (Result == null)
                Console.WriteLine("Cannot show results before Solve() is called");

            Console.WriteLine($"Small: {Small}, Big length: {Big.Length}, Matches found: {Result.Count}");

            if (Result.Count == 0)
                return;

            if (PrintOccurences)
            {
                var valueChar = '_';
                var useStaticValue = true;

                Action<int> write = (idx) =>
                {
                    var separator = ' ';
                    var smallLength = Small.Length;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(new string(separator, idx));
                    var value = useStaticValue ? new string(valueChar, smallLength) : Big.Substring(idx, smallLength);
                    sb.Append(value);
                    sb.Append(new string(separator, Big.Length - idx - smallLength));
                    Console.WriteLine(sb.ToString());
                };

                Result.ForEach(x => write(x));
            }
        }

        public static void Test(int numberOfRuns, string validChars = "abc")
        {
            var smallLength = 5;
            var bigLength = 50000000;
            var elapsedList = new List<long>(numberOfRuns);

            Enumerable.Range(1, numberOfRuns).ForEach(x =>
            {
                var randomSmall = Tools.String.RandomString(validChars, smallLength);
                var randomBig = Tools.String.RandomString(validChars, bigLength);
                var elapsedMs = Metrics.Run(new StringPermutations(randomSmall, randomBig));
                elapsedList.Add(elapsedMs);
            });

            Console.WriteLine($"Average execution time: {elapsedList.Average()}ms");
        }
    }
}
