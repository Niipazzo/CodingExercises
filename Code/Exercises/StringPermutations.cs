using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Niipazzo.Exercises
{
    /// Example: Given a smaller string 5 and a bigger string b, design an algorithm to find all permutations of the shorter string within the longer one.
    /// Print the location of each permutation
    /// 
    /// From book: Cracking coding interview by Gayle Laakmann 2016
    /// Page: 69
    public class StringPermutations
    {
        public string Small { get; }
        public string Big { get; }

        private List<int> Result { get; set; }
        
        public StringPermutations(string small = null, string big = null)
        {
            //Init with example values from book
            Small = small ?? "abbc";
            Big = big ?? "cbabadcbbabbcbabaabccbabc";
        }

        public void SolveAndRender()
        {
            Solve();
            Render();
        }

        public void Solve()
        {
            SolveUsingSortArray();
        }

        private void SolveUsingSortArray()
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

        public void Render()
        {
            if (Result == null)
                Console.WriteLine("Cannot show results before Solve() is called");

            Console.WriteLine($"Matches found: {Result.Count}");

            if (Result.Count == 0)
                return;

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
}
