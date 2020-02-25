using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Niipazzo.Exercises
{
    public class StringPermutations
    {
        private string Small { get; }
        private string Big { get; }
        
        public StringPermutations(string small, string big)
        {
            Small = small;
            Big = big;
        }

        /// <summary>
        /// Example: Given a smaller string 5 and a bigger string b, design an algorithm to find all permutations of the shorter string within the longer one.
        /// Print the location of each permutation
        /// 
        /// From book: Cracking coding interview by Gayle Laakmann 2016
        /// Page: 69
        /// </summary>
        /// <param name="small"></param>
        /// <param name="big"></param>
        public void Solve()
        {
            var result = SolveUsingSortArray();
            RenderResults(result);
        }

        private List<int> SolveUsingSortArray()
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
            return result;
        }

        private void RenderResults(List<int> indexes)
        {
            Console.WriteLine($"Matches found: {indexes.Count}");
            Console.WriteLine(Big);

            Action<int> write = (idx) =>
            {
                var separator = ' ';
                var smallLength = Small.Length;
                StringBuilder sb = new StringBuilder();
                sb.Append(new string(separator, idx));
                sb.Append(Big.Substring(idx, smallLength));
                sb.Append(new string(separator, Big.Length - idx - smallLength));
                Console.WriteLine(sb.ToString());
            };

            indexes.ForEach(x => write(x));
        }
    }
}
