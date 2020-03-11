using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Niipazzo.Tools;

namespace Niipazzo.Exercises.One
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
            Solve3();
        }

        /// <summary>
        /// Validchars = "abc"
        /// Small.Length = 100
        /// Big.Length = 50Mil
        /// Avg execution is 92000ms
        /// 
        /// Uses Array.Sort and SequenceEqual
        /// </summary>
        private void Solve1()
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
        /// Small.Length = 100
        /// Big.Length = 50Mil
        /// Avg execution is 82000ms
        /// 
        /// Uses Array.Sort and For loop comparison
        /// </summary>
        private void Solve2()
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

        /// <summary>
        /// Validchars = "abc"
        /// Small.Length = 100
        /// Big.Length = 50Mil
        /// Avg execution is 7500ms
        /// 
        /// doesnt use substrings to compare
        /// </summary>
        private void Solve3()
        {
            var result = new List<int>();
            var smallIndex = new Dictionary<char, int>();
            var bigIndex = new Dictionary<char, int>();
            var smallLength = Small.Length;

            Action< Dictionary<char, int>, char> dictionaryAdd = (dic, x) =>
            {
                if (!dic.ContainsKey(x))
                {
                    dic.Add(x, 0);
                }

                dic[x] += 1;
            };

            Small.ForEach(x => dictionaryAdd(smallIndex, x));

            for (int i = 0; i < Big.Length; i++)
            {
                dictionaryAdd(bigIndex, Big[i]);
                if (i - smallLength >= 0 && bigIndex.ContainsKey(Big[i - smallLength]))
                {
                    bigIndex[Big[i - smallLength]] -= 1;
                }

                if (smallIndex.All(x => bigIndex.ContainsKey(x.Key) && x.Value == bigIndex[x.Key]))
                {
                    result.Add(i - smallLength + 1);
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
                Console.WriteLine(Big);

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

        public static void Test(int numberOfRuns, string validChars = "abc", int smallLength = 5, int bigLength = 50000000)
        {
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
